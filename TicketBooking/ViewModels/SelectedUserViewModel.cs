using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data.Models;

namespace TicketBooking.ViewModels
{
    public class SelectedUserViewModel
    {
        [Display(Name = "Введите имя:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле Имя задано неверно")]
        [MinLength(10, ErrorMessage = "Ошибка, поле заполнено некорректно")]
        public string Name { get; set; }

        [Display(Name = "Введите фамилию:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле Имя задано неверно")]
        [MinLength(10, ErrorMessage = "Ошибка, поле заполнено некорректно")]
        public string Surname { get; set; }

        [Display(Name = "Введите логин:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле логин задано неверно")]
        [DataType(DataType.EmailAddress)]
        [MinLength(15, ErrorMessage = "Ошибка, поле заполнено некорректно")]
        public string Login { get; set; }

        [Display(Name = "Введите пароль:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле пароль задано неверно")]
        [DataType(DataType.Password)]
        [MinLength(10, ErrorMessage = "Ошибка, поле заполнено некорректно")]
        public string Password { get; set; }

        [Display(Name = "Подтвердите пароль:")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirnPassword { get; set; }

        public int UserID { get; set; }
        public bool IsUserValid { get; set; }

        public Guid ActivateCode { get; set; }
    }
}
