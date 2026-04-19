using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class paypal: Ipayment, Ilogable
    {
        public string GetPaymenttype() => "Paypal Payment";

        public void log()
        {
            Console.WriteLine("paypal log");
        }

        public bool ProcessPayment(decimal amount)
        {
            if (amount > 0)
            {
                Console.WriteLine($"Processing Paypal payment of {amount}");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid amount for Paypal payment.");
                return false;
            }
        }
    }
}
