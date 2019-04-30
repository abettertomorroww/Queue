using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queue.ViewModels
{
    /// <summary>
    /// модель создания пользователя
    /// </summary>
    public class CreateUserViewModel
    {
        /// <summary>
        /// почта пользователя
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// пароль пользователя
        /// </summary>
        public string Password { get; set; }
    }
}
