using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class emailClient:INotificationChanell
    {
        public void send(string message)
        {
            Console.WriteLine($"[Email] {message}");
            Console.WriteLine("-----------------------------");

        }
    }
}
