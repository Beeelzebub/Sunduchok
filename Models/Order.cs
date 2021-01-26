using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Сундучок.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime StartDate {get ; set;}
        public DateTime EndTime { get; set; }
        
        [ForeignKey("User")]
        public int CustomerId { get; set; }
        public User Customer { get; set; }

        [ForeignKey("User")]
        public int SellerId { get; set; }
        public User Seller { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
