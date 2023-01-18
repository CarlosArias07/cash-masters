using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMastersPOS
{
    public class ChangeCalculator : ICalculator
    {
        public double CalculateChange(double productPrice, List<double> billsAndCoinsProvided)
        {
            if (productPrice <= 0)
                throw new InvalidOperationException("Product does not have a price.");

            if (billsAndCoinsProvided == null || billsAndCoinsProvided.Count == 0)
                throw new InvalidOperationException("No bills/coins provided.");

            // Subtract total payed amount - product price to obtain change amount
            var totalPayedAmount = Math.Round(billsAndCoinsProvided.Sum(), 2);
            var changeAmount = Math.Round(totalPayedAmount - productPrice, 2);

            return changeAmount;
        }

        public List<double> CalculateChangeDenominations(double productPrice, List<double> billsAndCoinsProvided)
        {
            if (productPrice == 0)
                throw new InvalidOperationException("Product does not have a price.");

            if (billsAndCoinsProvided == null || billsAndCoinsProvided.Count == 0)
                throw new InvalidOperationException("No bills/coins provided.");

            // Calculate change amount
            var changeAmount = Math.Round(CalculateChange(productPrice, billsAndCoinsProvided), 2);

            // Sort currency denominations list in descending order
            var currency = new Currency();
            var denominations = currency.Denominations.OrderByDescending(n => n).ToList();

            var list = new List<double>();
            var index = 0;
            // count will increase until it matches the change amount
            double count = 0;

            // Algorithm complexity: O(n)
            while (count < changeAmount && index < denominations.Count)
            {
                var currentDenomination = denominations[index];
                var diff = Math.Round(changeAmount - count, 2);

                if (currentDenomination <= diff)
                {
                    count += Math.Round(currentDenomination, 2);
                    list.Add(currentDenomination);
                }
                else
                    index++;
            }

            return list;
        }
    }
}
