using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMastersPOS
{
    public class Currency
    {
        public string Code { get; }
        public List<double> Denominations { get; }

        public Currency()
        {
            Code = "USD";
            Denominations = new List<double>
            {
                0.01,
                0.05,
                0.10,
                0.25,
                0.5,
                1,
                2,
                5,
                10,
                20,
                50,
                100
            };
        }
    }
}
