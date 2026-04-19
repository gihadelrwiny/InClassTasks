using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class QNB : Ipayment
    {
        public string GetPaymenttype() => "QNB Payment";





        public bool ProcessPayment(decimal amount)
        {
            if (amount > 0)
            {
                Console.WriteLine($"Processing QNB payment of {amount}");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid amount for QNB payment.");
                return false;
            }
        }
    }
}
