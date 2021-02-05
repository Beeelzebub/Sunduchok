using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Сундучок.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime StartDate {get ; set;}
        
        [ForeignKey("User")]
        public string CustomerId { get; set; }
        public User Customer { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public string Cart { get; set; }

        public Cart GetCartObject()
        {
            return JsonSerializer.Deserialize<Cart>(Cart);
        }
    }
}
