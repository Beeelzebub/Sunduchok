using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Сундучок.Models
{
    public class Review
    {
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }

    }
}
