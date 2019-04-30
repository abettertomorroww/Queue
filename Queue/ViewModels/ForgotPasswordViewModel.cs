using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Queue.ViewModels
{
    /// <summary>
    /// модель сброса пароля 
    /// </summary>
    public class ForgotPasswordViewModel
    {
        /// <summary>
        /// почта пользователя
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
