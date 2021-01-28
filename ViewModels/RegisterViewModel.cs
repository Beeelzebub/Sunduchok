using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Сундучок.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
