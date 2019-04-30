using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    /// <summary>
    /// интерфейс работы с пользователем
    /// </summary>
    public interface IUserBusinessService
    {
        /// <summary>
        /// регистрация пользователя
        /// </summary>
        /// <param name="user">пользователь</param>
        /// <param name="pass">пароль</param>
        /// <returns></returns>
        Task<IdentityResult> Register(UserBusiness user, string pass);

        /// <summary>
        /// вход на сайт при регистрации
        /// </summary>
        /// <param name="user">пользователь</param>
        /// <returns></returns>
        Task SignIn(UserBusiness user);

        /// <summary>
        /// вход на сайт по паролю
        /// </summary>
        /// <param name="email">почта</param>
        /// <param name="pass">пароль</param>
        /// <param name="rememberMe">флажок запоминания на сайте</param>
        /// <returns></returns>
        Task<Microsoft.AspNetCore.Identity.SignInResult> PasswordSignIn(string email, string pass, bool rememberMe);

        /// <summary>
        /// сброс пароля
        /// </summary>
        /// <param name="email">почта</param>
        /// <param name="callBackUrl">строка обратной связи</param>
        /// <returns></returns>
        Task ForgotPassword(string email, string callBackUrl);

        /// <summary>
        /// подтверждение регистрации
        /// </summary>
        /// <param name="email">почта</param>
        /// <param name="callBackUrl">строка обратной связи</param>
        /// <returns></returns>
        Task RegistrationConfirm(string email, string callBackUrl);
    }
}
