using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Models
{
    /// <summary>
    /// модель логов(BL)
    /// </summary>
    public class LogsModel
    {
        /// <summary>
        /// дата
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// текст логов 
        /// </summary>
        public string Text { get; set; }
    }
}
