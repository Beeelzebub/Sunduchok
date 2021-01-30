using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Сундучок.ViewModels
{
    public class EditProductViewModel : ProductViewModel
    {
        public int Id { get; set; }
        
    }
}
