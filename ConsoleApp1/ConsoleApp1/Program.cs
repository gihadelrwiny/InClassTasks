namespace ConsoleApp1
{
    internal class Program
    {
        public delegate double Calculator(double a, double b);
        static void Main(string[] args)
        {
            var email = "Gihad@gmail.com";

            Console.WriteLine(email.IsValidEmail());   // true
            var text = "Hello World from C# 12";
            Console.WriteLine(text.WordCount());
            Console.WriteLine(text.ToPascalCase());
            var x = 4;
            Console.WriteLine(x.IsEven());
            Console.WriteLine(x.IsOdd());
            Console.WriteLine(x.Clamp(1, 3)); // Output: 3

            Console.WriteLine("--------------------------------------");
            Calculator Add = (a, b) => a + b;
            Calculator Subtract = (a, b) => a - b;
            Calculator Multiply = (a, b) => a * b;
            Calculator Divide = (a, b) => b != 0 ? a / b : 0;

            Console.WriteLine($"Add = {Add(10, 5)}");
            Console.WriteLine($"Subtract = {Subtract(10, 5)}");
            Console.WriteLine($"Multiply = {Multiply(10, 5)}");
            Console.WriteLine($"Divide = {Divide(10, 5)}");

            // Multicast Delegate
            Calculator calc =Add;

            
            calc += Subtract;
            calc += Multiply;
            calc += Divide;

            Console.WriteLine("\nMulticast Delegate:");
            Console.WriteLine(calc(10, 5));
         
            Console.WriteLine("--------------------------------------");
            // Action Logger
            Action<string> logger = message =>
            {
                Console.WriteLine(message);
            };

            logger += message =>
            {
                File.AppendAllText("log.txt", message + Environment.NewLine);
            };

            logger("Application Started");
            logger("Test Message");
            Console.WriteLine("--------------------------------------");
                Predicate<int> isDivisibleBy3 = x => x % 3 == 0;

            List<int> numbers = new List<int> { 1, 3, 4, 6, 9, 10 };

            List<int> filtered = numbers.FindAll(isDivisibleBy3);

            Console.WriteLine("Divisible by 3:");
            foreach (var n in filtered)
                Console.WriteLine(n);

        }
    
    }
}
