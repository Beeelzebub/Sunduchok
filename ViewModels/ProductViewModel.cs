using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Сундучок.ViewModels
{
    public class ProductViewModel
    {
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Выберете категорию")]
        public int ProductTypeId { get; set; }

        public virtual IFormFile Image { get; set; }
    }
}
