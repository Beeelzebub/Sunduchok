using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Сундучок.ViewModels
{
    public class PayViewModel
    {
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [RegularExpression(@"\d{16}", ErrorMessage = "Номер ввведен неверно")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [RegularExpression(@"\d{2}/\d{2}", ErrorMessage = "Дата введена неверно")]
        public string Date { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [DataType(DataType.Password, ErrorMessage = "Поле должно быть заполнено")]
        public int CVC {get; set;}

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string Owner { get; set; }
    }
}
