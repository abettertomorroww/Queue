using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queue.ViewModels
{
    /// <summary>
    /// модель редактирования пользователя 
    /// </summary>
    public class EditUserViewModel
    {
        /// <summary>
        /// индификатор пользователя
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// почта пользователя
        /// </summary>
        public string Email { get; set; }
    }
}
