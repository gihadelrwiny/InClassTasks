using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class NotificationService
    {
        private readonly INotificationChanell _notificationChanell;
        private readonly IMessageLogge _messageLogge;
        public NotificationService(INotificationChanell notificationChanell, IMessageLogge messageLogge)
        {
            _notificationChanell = notificationChanell;
            _messageLogge = messageLogge;
        }
        public void send(string message)
        {
            _notificationChanell.send(message);
            _messageLogge.log(message);
        }
    }
}
