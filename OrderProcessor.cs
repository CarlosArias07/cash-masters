using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMastersPOS
{
    public class OrderProcessor
    {
        private readonly ICalculator _calculator;

        public OrderProcessor(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public void Process(Product product, List<double> billsAndCoinsProvidedByCustomer)
        {
            if (product == null)
                throw new InvalidOperationException("Invalid product.");

            if (billsAndCoinsProvidedByCustomer == null || billsAndCoinsProvidedByCustomer.Count == 0)
                throw new InvalidOperationException("No bills/coins provided.");

            var currency = new Currency();

            Console.WriteLine("Currency: {0}", currency.Code);
            Console.WriteLine("Product price: {0}", product.Price);
            Console.WriteLine("Bills and coins provided by customer: {0}", string.Join(", ", billsAndCoinsProvidedByCustomer));

            ProcessChange(product, billsAndCoinsProvidedByCustomer);
        }

        private void ProcessChange(Product product, List<double> billsAndCoinsProvidedByCustomer)
        {
            // Obtain change amount
            var change = _calculator.CalculateChange(product.Price, billsAndCoinsProvidedByCustomer);

            if (change > 0)
            {
                Console.WriteLine("Change amount: {0}", change);

                // Calculate the required denominations to return
                var billsAndCoinsReturned = _calculator.CalculateChangeDenominations(product.Price, billsAndCoinsProvidedByCustomer);

                Console.WriteLine("Bills and coins to return to customer: {0}", string.Join(", ", billsAndCoinsReturned));
            }
            else if (change == 0)
                Console.WriteLine("No change needed.");
            else
                throw new InvalidOperationException("Payment error. Amount provided by customer is incorrect.");
        }
    }
}
