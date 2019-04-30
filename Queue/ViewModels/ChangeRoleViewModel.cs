using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queue.ViewModels
{
    /// <summary>
    /// модель изменения ролей
    /// </summary>
    public class ChangeRoleViewModel
    {
        /// <summary>
        /// индификатор пользователя 
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// почта пользователя
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// список всех ролей
        /// </summary>
        public List<IdentityRole> AllRoles { get; set; }
        
        /// <summary>
        /// список ролей пользователя
        /// </summary>
        public IList<string> UserRoles { get; set; }

        /// <summary>
        /// конструктор модели изменения ролей
        /// </summary>
        public ChangeRoleViewModel()
        {
            AllRoles = new List<IdentityRole>();
            UserRoles = new List<string>();
        }
    }
}
