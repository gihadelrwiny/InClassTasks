using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal interface Ipayment
    {
        bool ProcessPayment(decimal amount);
        string GetPaymenttype();
    }
}
