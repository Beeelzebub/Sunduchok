using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Сундучок.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

        public int PictureId { get; set; }
        public Picture Picture { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        public List<Review> Reviews { get; set; }

        public Product()
        {
            Reviews = new List<Review>();
        }

    }
}
