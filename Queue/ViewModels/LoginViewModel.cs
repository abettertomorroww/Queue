using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Queue.ViewModels
{
    /// <summary>
    /// модель входа на сайт
    /// </summary>
    public class LoginViewModel
    { 
        /// <summary>
        /// почта пользователя
        /// </summary>
        [EmailAddress]
        [Required(ErrorMessage = "The field must be filled in")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// пароль пользователя
        /// </summary>
        [Required(ErrorMessage = "The field must be filled in")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// флажок запоминания на сайте
        /// </summary>
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        /// <summary>
        /// строка возврата
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}
