using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Сундучок.Models
{
    public class Cart
    {
        public List<CartLine> lineCollection { get; set; }
        public Cart()
        {
            lineCollection = new List<CartLine>();
        }
        public IEnumerable<CartLine> Lines() { return lineCollection; }
        public void AddItem(Product product)
        {
            CartLine line = lineCollection
                .Where(g => g.Product.Id == product.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = new ShortProduct
                    { 
                        Id = product.Id, 
                        Name = product.Name, 
                        Price = product.Price, 
                        Picture = product.Picture 
                    },
                    Count = 1
                });
            }
            else
            {
                line.Count++;
            }
        }
        public void RemoveItem(Product product)
        {
            CartLine line = lineCollection
                .Where(g => g.Product.Id == product.Id)
                .FirstOrDefault();
            if (line != null)
            {
                line.Count--;
            }
            if (line.Count <= 0)
            {
                lineCollection.Remove(line);
            }
        }

        public float GetSum()
        {
            return lineCollection.Sum(l => l.Product.Price * l.Count);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }
    }

    public class CartLine
    {
        public ShortProduct Product { get; set; }
        public int Count { get; set; }
    }

    public class ShortProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public Picture Picture { get; set; }

    }

}
