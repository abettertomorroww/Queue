using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLogicLayer.Models
{
    /// <summary>
    /// модель очереди (DL)
    /// </summary>
    public class QueueData
    {
        /// <summary>
        /// индификатор очереди
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// имя пользователя
        /// </summary>
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "The length of the string must be between 2 to 20 characters")]
        [Display(Name = "Name")]
        public string UserName { get; set; }

        /// <summary>
        /// номер микроволновки
        /// </summary>
        [Display(Name = "Microwave number")]
        public string Microwave { get; set; }

        /// <summary>
        /// время для использования 
        /// </summary>
        [Display(Name = "Time of use")]
        public DateTime Time { get; set; }

        /// <summary>
        /// номер в очереди
        /// </summary>
        [Display(Name = "The number in the queue")]
        public string NumberQueue { get; set; }
    }
}
