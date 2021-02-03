using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Сундучок.ViewModels
{
    public class DelivaryViewModel
    {
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string City { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public int Hous { get; set; }

        public int? Porch { get; set; }

        public int? Apartment { get; set; }

    }
}
