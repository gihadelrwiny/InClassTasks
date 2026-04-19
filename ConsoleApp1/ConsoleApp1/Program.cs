namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Ipayment> list = new List<Ipayment>()
           {
                new QNB(),
                new paypal(),
                new payment3()
              };
            BankAcoount account = new BankAcoount();
            foreach (var item in list)
            {
                account.Deposit(100, item);
            }

        } 
    }
}
