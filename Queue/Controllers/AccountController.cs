using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Queue.Models;
using Queue.ViewModels;
using Queue.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DataLogicLayer.Models;

namespace Queue.Controllers
{
    /// <summary>
    /// контроллер регистрации/авторизации пользователей
    /// </summary>
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<UserData> _userManager;
        private readonly SignInManager<UserData> _signInManager;
        private readonly IUserService _userService;
        private readonly ILogger _logger;

        public AccountController(UserManager<UserData> userManager, SignInManager<UserData> signInManager, IUserService userService, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
            _logger = logger;
        }

        /// <summary>
        /// получаем страницу регистрации пользователя
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// возвращаем метод регистрации пользователя
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserData user = new UserData { Email = model.Email, UserName = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result != null)
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action(
                        "ConfirmEmail",
                        "Account",
                        new { userId = user.Id, code = code },
                        protocol: HttpContext.Request.Scheme);

                    await _userService.RegistrationConfirm(model.Email, callbackUrl);
                    return RedirectToAction("Confirm");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        /// <summary>
        /// получаем страницу подтверждения почты
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Confirm()
        {
            return View();
        }

        /// <summary>
        /// возвращаем метод подтверждения почты
        /// </summary>
        /// <param name="userId">индификатор пользователя</param>
        /// <param name="code">маркер подтверждения почты</param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View("Error");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
                return RedirectToAction("Index", "Home");
            else
                return View("Error");
        }

        /// <summary>
        /// получаем страницу аунтификации пользователя
        /// </summary>
        /// <param name="returnUrl">строка возврата</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Auth(string returnUrl = null)
        {
            return View(new AuthViewModel(_signInManager) { ReturnUrl = returnUrl });
        }

        /// <summary>
        /// получаем страницу входа на сайт
        /// </summary>
        /// <param name="returnUrl">строка возврата</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        /// <summary>
        /// возвращаем метод входа на сайт
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Email);
                if (user != null)
                {
                    if (!await _userManager.IsEmailConfirmedAsync(user))
                    {
                        ModelState.AddModelError(string.Empty, "You have not confirmed your email");
                        return View(model);
                    }
                }

                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        _logger.LogInformation("User id {UserId} went to the site in {RequestTime}.", user.Id, DateTime.Now);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    _logger.LogWarning("Incorrect data entered for user with id {UserId} in {RequestTime}.", user.Id, DateTime.Now);
                    ModelState.AddModelError("", "Incorrect username and/or password");
                }
            }
            return View(model);
        }

        /// <summary>
        /// получает страницу сброса пароля
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        /// <summary>
        /// вовращаем метод сброса пароля
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    return View("ForgotPasswordConfirmation");
                }

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);

                string callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                await _userService.ForgotPassword(model.Email, callbackUrl);
                return View("ForgotPasswordConfirmation");
            }
            return View(model);
        }


        /// <summary>
        /// получает страницу повторной установки пароля
        /// </summary>
        /// <param name="code">маркер сброса пароля</param>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string code = null)
        {
            return code == null ? View("Error") : View();
        }

        /// <summary>
        /// возвращаем метод повторной установки пароля
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                return View("ResetPasswordConfirmation");
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return View("ResetPasswordConfirmation");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }

        /// <summary>
        /// возвращаем метод выхода с сайта
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
