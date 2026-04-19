using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class BankAcoount
    {
        private decimal _balance;
        public decimal Balance { 
            get { return _balance; } set {
                if (value < 0)
                {
                    Console.WriteLine("Balance cannot be negative.");
                }
                else
                {
                    _balance = value;
                }
                }
        }
        public void Deposit(decimal balance, Ipayment payment)
        {
                        if (payment.ProcessPayment(balance))
            {
                Console.WriteLine( payment.GetPaymenttype() + " payment processed successfully.");
            }
        }

    }
}
