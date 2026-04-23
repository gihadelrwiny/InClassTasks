using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class SmsChannel:INotificationChanell
    {
        public void send(string message)
        {
            Console.WriteLine($"[SMS] {message}");
        }
    
    }
}
