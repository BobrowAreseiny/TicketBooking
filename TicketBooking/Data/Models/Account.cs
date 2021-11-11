using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBooking.Data.Models
{
    public class Account
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Введите логин:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле логин задано неверно")]
        [DataType(DataType.EmailAddress)]
        [MinLength(15,ErrorMessage = "Ошибка, поле заполнено некорректно")]
        public string Login { get; set; }

        [Display(Name = "Введите пароль:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле пароль задано неверно")]
        [DataType(DataType.Password)]
        [MinLength(10, ErrorMessage = "Ошибка, поле заполнено некорректно")]
        public string Password { get; set; }

        [Display(Name = "Подтвердите пароль:")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Пароли не совпадают")]
        public string ConfirnPassword { get; set; }

        public Guid ActivateCode { get; set; }
        public int UserID { get; set; }          
        public bool IsUserValid { get; set; }   
              
        public virtual User User { get; set; }

        public List<Ticket> Ticket { get; set; }

    }
}
