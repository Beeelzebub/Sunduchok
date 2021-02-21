using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Сундучок.Models;

namespace Сундучок.ViewModels
{
    public class AssortmentViewModel
    {
        public List<Product> Products { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }

    }
}
