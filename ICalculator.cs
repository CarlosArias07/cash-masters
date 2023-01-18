using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMastersPOS
{
    public interface ICalculator
    {
        double CalculateChange(double productPrice, List<double> billsAndCoinsProvided);

        List<double> CalculateChangeDenominations(double productPrice, List<double> billsAndCoinsProvided);
    }
}
