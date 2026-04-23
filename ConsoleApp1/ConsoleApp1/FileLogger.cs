using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class FileLogger:IMessageLogge
    {
        public void log(string message)
        {
            Console.WriteLine($"[Log] {message}");
            Console.WriteLine("-----------------------------");
        }
    }
}
