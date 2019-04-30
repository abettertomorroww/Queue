using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLogicLayer.Models
{
    /// <summary>
    /// модель пользователя(DL)
    /// </summary>
    public class UserData : IdentityUser
    {
        /// <summary>
        /// имя пользователя
        /// </summary>
        public string FullName { get; set; }
    }
}
