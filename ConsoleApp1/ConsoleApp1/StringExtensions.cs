using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class StringExtensions
    {
        public static bool IsValidEmail(this string email)
        {
            return email.Contains("@") && email.Contains(".");
        }
        public static int WordCount(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return 0;
            var words = str.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }   
        public static string ToPascalCase(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;
            var words = str.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var pascalCase = string.Join("", words.Select(w => char.ToUpper(w[0]) + w.Substring(1).ToLower()));
            return pascalCase;
        }
    }
}
