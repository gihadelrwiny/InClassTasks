using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class payment3: Ipayment,Ilogable
    {
        public string GetPaymenttype() => "Payment3 Payment";

        public void log()
        {
            Console.WriteLine("paymen3 log");
        }

        public bool ProcessPayment(decimal amount)
        {
            if (amount > 0)
            {
                Console.WriteLine($"Processing Payment3 payment of {amount}");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid amount for Payment3 payment.");
                return false;
            }
        }
    
    }
}
