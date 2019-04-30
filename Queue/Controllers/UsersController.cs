using DataLogicLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Queue.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queue.Controllers
{
    /// <summary>
    /// контроллер управления ролями
    /// </summary>
    //[Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        UserManager<UserData> _userManager;

        public UsersController(UserManager<UserData> userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// получаем список пользователей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index() => View(_userManager.Users.ToList());

        /// <summary>
        /// получаем страницу добавления пользователей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create() => View();

        /// <summary>
        /// возвращаем метод создания пользователя
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserData user = new UserData { Email = model.Email, UserName = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
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
        /// получаем страницу редактирования данных пользователя
        /// </summary>
        /// <param name="id">индификатор пользователя</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            UserData user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            EditUserViewModel model = new EditUserViewModel { Id = user.Id, Email = user.Email };
            return View(model);
        }

        /// <summary>
        /// возвращаем метод редактирования данных пользователя
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserData user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.Email;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }

        /// <summary>
        /// получаем стараницу удаления записи о пользователе
        /// </summary>
        /// <param name="id">индификатор пользователя</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            UserData user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// возвращаем метод удаления записи о пользователе
        /// </summary>
        /// <param name="id">индификатор пользователя</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ChangePassword(string id)
        {
            UserData user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ChangePasswordViewModel model = new ChangePasswordViewModel { Id = user.Id, Email = user.Email };
            return View(model);
        }

        /// <summary>
        /// возвращаем метод смены пароля
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserData user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    IdentityResult result =
                        await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User is not found");
                }
            }
            return View(model);
        }
    }
}
