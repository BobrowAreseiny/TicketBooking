using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBooking.Data.Models
{
    public class Client
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Введите имя:")]
        [Required(AllowEmptyStrings = false ,ErrorMessage = "Поле Имя задано неверно")]
        [MinLength(10, ErrorMessage = "Ошибка, поле заполнено некорректно")]
        public string Name { get; set; }

        [Display(Name = "Введите фамилию:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле Имя задано неверно")]
        [MinLength(10, ErrorMessage = "Ошибка, поле заполнено некорректно")]
        public string Surname { get; set; }

        [Display(Name = "Введите дату рождения:")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true , DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfBirth { get; set; }     
    }
}
