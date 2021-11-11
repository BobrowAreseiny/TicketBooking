using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBooking.Data.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Введите имя:")]
        [Required(AllowEmptyStrings = false ,ErrorMessage = "Поле Имя задано неверно")]
        public string Name { get; set; }

        [Display(Name = "Введите фамилию:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле Имя задано неверно")]
        public string Surname { get; set; }
        
        public List<Account> Ticket { get; set; }
    }
}
