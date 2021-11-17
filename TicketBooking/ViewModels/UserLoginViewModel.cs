using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data.Models;

namespace TicketBooking.ViewModels
{
    public class UserLoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле задано неверно")]
        [DataType(DataType.EmailAddress)]
        [MinLength(15, ErrorMessage = "Ошибка, поле заполнено некорректно")]
        public string Login { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле задано неверно")]
        [DataType(DataType.Password)]
        [MinLength(10, ErrorMessage = "Ошибка, поле заполнено некорректно")]
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
