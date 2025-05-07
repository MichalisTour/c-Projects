using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp
{
    internal class Product
    {
            public string Name { get; set; }
            public float Price { get; set; }
            public string Category { get; set; }
            public int Quantity { get; set; }

            public Product(string name, float price, string category)
            {
                Name = name;
                Price = price;
                Category = category;
                Quantity = 0;
            }
        }
}
