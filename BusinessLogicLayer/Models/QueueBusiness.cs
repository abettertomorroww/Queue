using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLogicLayer.Models
{
    /// <summary>
    /// модель очереди (BL)
    /// </summary>
    public class QueueBusiness
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
        /// номер комнаты
        /// </summary>
        [Range(1, 2)]
        [Display(Name = "The number the room")]
        public int NumberRoom { get; set; }

        /// <summary>
        /// номер микроволновки
        /// </summary>
        [Display(Name = "Microwave number")]
        public int Microwave { get; set; }

        /// <summary>
        /// время для использования 
        /// </summary>
        [Display(Name = "Time of use")]
        public DateTime Time { get; set; }

        
    }
}
