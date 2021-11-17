using System;
using System.ComponentModel.DataAnnotations;
using TicketBooking.Data.Models;

namespace TicketBooking.ViewModels
{
    public class AccountViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле задано неверно")]
        [DataType(DataType.EmailAddress)]
        [MinLength(15, ErrorMessage = "Ошибка, поле заполнено некорректно")]
        public string Login { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле задано неверно")]
        [DataType(DataType.Password)]
        [MinLength(10, ErrorMessage = "Ошибка, поле заполнено некорректно")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле задано неверно")]
        [MinLength(10, ErrorMessage = "Ошибка, поле заполнено некорректно")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле задано неверно")]
        [MinLength(10, ErrorMessage = "Ошибка, поле заполнено некорректно")]
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public bool RememberMe { get; set; }

        public Role Role { get; set; }
    }
}
