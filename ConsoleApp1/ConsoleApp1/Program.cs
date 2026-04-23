namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var NotificationChanell = new emailClient();
            var logger = new FileLogger();
            var notificationService = new NotificationService(NotificationChanell, logger);
            notificationService.send("Hello from Session 7!");
            Console.WriteLine("-----------------------------");
            List<INotificationChanell> notificationChanells = new List<INotificationChanell>
            {
                new emailClient(),
                new SmsChannel(),
            };
            foreach (var chanell in notificationChanells)
            {
                chanell.send("Hello from Session 7!");
                Console.WriteLine("-----------------------------");
            }
        }
    }
}
