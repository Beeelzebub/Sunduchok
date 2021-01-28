using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Сундучок.ViewModels
{
    public class RegisterViewModel : AccountViewModel
    {
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public override string FirstName { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public override string SecondName { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public override string RegisterUserName { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public override string RegisterPassword { get; set; }
    }
}
