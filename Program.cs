using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMastersPOS
{
    public class Program
    {
        private static void Main()
        {
            var orderProcessor = new OrderProcessor(new ChangeCalculator());
            // Inputs ------------------------------------------------------
            var product = new Product(5.25);
            var billsAndCoinsProvidedByCustomer = new List<double> { 5.0, 5.0 };
            // -------------------------------------------------------------

            orderProcessor.Process(product, billsAndCoinsProvidedByCustomer);
        }
    }
}
