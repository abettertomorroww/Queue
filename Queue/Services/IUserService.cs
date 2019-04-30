using Microsoft.AspNetCore.Identity;
using Queue.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Queue.Services
{
    /// <summary>
    /// интерфейс работы с пользователем
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="user">пользователь</param>
        /// <param name="pass">имя пользователя</param>
        /// <returns></returns>
        Task<IdentityResult> Register(User user, string pass);

        /// <summary>
        /// вход на сайт(при регистрации)
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task SignIn(User user);

        /// <summary>
        /// вход на сайт по паролю
        /// </summary>
        /// <param name="email">почта</param>
        /// <param name="pass">пароль</param>
        /// <param name="rememberMe">флажок - запомни меня на сайте</param>
        /// <returns></returns>
        Task<SignInResult> PasswordSignIn(string email, string pass, bool rememberMe);

        /// <summary>
        /// сброс пароля
        /// </summary>
        /// <param name="email">почта</param>
        /// <param name="callbackURL">строка call back</param>
        /// <returns></returns>
        Task ForgotPassword(string email, string callbackURL);

        /// <summary>
        /// подтверждение регистрации
        /// </summary>
        /// <param name="email">почта</param>
        /// <param name="callbackURL">строка call back</param>
        /// <returns></returns>
        Task RegistrationConfirm(string email, string callbackURL);
    }
}
