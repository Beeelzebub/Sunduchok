using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Сундучок.ViewModels
{
    public class CreateProductViewModel : ProductViewModel
    {

        [Required(ErrorMessage = "Загрузите изображение для товара")]
        public override IFormFile Image { get; set; }
    }
}
