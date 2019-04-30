using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Queue.ViewModels
{
    /// <summary>
    /// модель отображения логов
    /// </summary>
    public class LogsViewModel
    {
        /// <summary>
        /// дата
        /// </summary>
        [Required(ErrorMessage = "The field must be filled in")]
        public string Date { get; set; }

        /// <summary>
        /// текст логов
        /// </summary>
        public string Text { get; set; }
    }
}
