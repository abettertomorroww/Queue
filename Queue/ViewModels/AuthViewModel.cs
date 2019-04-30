using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Queue.Models;
using DataLogicLayer.Models;

namespace Queue.ViewModels
{
    /// <summary>
    /// модель аунтификации
    /// </summary>
    public class AuthViewModel : PageModel
    {
        /// <summary>
        /// сервис для аунтификации
        /// </summary>
        private readonly SignInManager<UserData> _signInManager;

        /// <summary>
        /// конструктор модели аунтификации
        /// </summary>
        public AuthViewModel(SignInManager<UserData> singInManager)
        {
            _signInManager = singInManager;
        }

        /// <summary>
        /// строка возврата
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// список внешних служб проверки подлинности 
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        /// сообщение об ошибке
        /// </summary>
        [TempData]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// получение списка служб проверки подлинности
        /// </summary>
        /// <param name="returnUrl">строка возврата</param>
        /// <returns></returns>
        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }
            returnUrl = returnUrl ?? Url.Content("~/");

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            ReturnUrl = returnUrl;
        }
    }
}
