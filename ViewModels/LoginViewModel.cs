using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Сундучок.ViewModels
{
    public class LoginViewModel : AccountViewModel
    {
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public override string LoginUserName { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public override string LoginPassword { get; set; }

        public override bool RememberMe { get; set; }
    }
}
