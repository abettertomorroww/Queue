﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Queue.ViewModels
{
    /// <summary>
    /// модель смены пароля 
    /// </summary>
    public class ResetPasswordViewModel
    {
        /// <summary>
        /// почта пользователя
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// пароль пользователя
        /// </summary>
        [RegularExpression(@"^(?=.*[a-z])[A-Za-z\d@$!%^*?=#/&-_+`{|}~]{6,12}$", ErrorMessage = "{0} must contain at least one letter ('a'-'z'), do not contain Russian letters, be at least 6 and no more than 12 characters.")]
        [Required(ErrorMessage = "The field must be filled in")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// подтверждение пароля 
        /// </summary>
        [Required(ErrorMessage = "The field must be filled in")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// маркер сброса пароля 
        /// </summary>
        public string Code { get; set; }
    }
}
