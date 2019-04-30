using DataLogicLayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLogicLayer.Services
{
    /// <summary>
    /// интерфейс работы с пользователем
    /// </summary>
    public interface IUserDataService
    {
        /// <summary>
        /// регистрация пользователя
        /// </summary>
        /// <param name="user">пользователь</param>
        /// <param name="pass">пароль</param>
        /// <returns></returns>
        Task<IdentityResult> Register(UserData user, string pass);

        /// <summary>
        /// вход на сайт при регистрации
        /// </summary>
        /// <param name="user">пользователь</param>
        /// <returns></returns>
        Task SignIn(UserData user);

        /// <summary>
        /// вход на сайт по паролю
        /// </summary>
        /// <param name="email">почта</param>
        /// <param name="pass">пароль</param>
        /// <param name="rememberMe">флажок запоминания на сайте</param>
        /// <returns></returns>
        Task<SignInResult> PasswordSignIn(string email, string pass, bool rememberMe);
    }
}
