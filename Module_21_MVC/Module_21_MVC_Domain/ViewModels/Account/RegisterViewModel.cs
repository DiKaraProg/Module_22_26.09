using Module_21_MVC_Domain.Unum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_21_MVC_Domain.ViewModels.Account
{
    public class RegisterViewModel
    {
        public int Id { get; set; }

        public Role Role { get; set; }

        [Required(ErrorMessage ="Укажите имя")]
        [MaxLength(20,ErrorMessage ="Не больше 20 символов")]
        [MinLength(6,ErrorMessage ="Не меньше 6 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите пароль")]
        [MinLength(6, ErrorMessage = "Не меньше 6 символов")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Укажите пароль")]
        [Compare("Password",ErrorMessage ="Пароли не совпадают")]
        public string PasswordConfirm { get; set; }

    }
}
