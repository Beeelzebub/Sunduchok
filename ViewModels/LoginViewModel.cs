using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Сундучок.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
