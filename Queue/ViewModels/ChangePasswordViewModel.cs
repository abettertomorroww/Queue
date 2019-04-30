using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queue.ViewModels
{
    /// <summary>
    /// модель изменения пароля
    /// </summary>
    public class ChangePasswordViewModel
    {
        /// <summary>
        /// индификатор пользователя 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// почта пользователя
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// новый пароль
        /// </summary>
        public string NewPassword { get; set; }

        /// <summary>
        /// старый пароль
        /// </summary>
        public string OldPassword { get; set; }
    }
}
