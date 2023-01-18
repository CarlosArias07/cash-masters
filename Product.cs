using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMastersPOS
{
    public class Product
    {
        public double Price { get; }

        public Product(double price)
        {
            Price = price;
        }
    }
}
