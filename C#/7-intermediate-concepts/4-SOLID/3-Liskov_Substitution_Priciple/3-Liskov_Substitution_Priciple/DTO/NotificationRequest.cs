using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Liskov_Substitution_Priciple.DTO
{
    public class NotificationRequest
    {
        public int NotificationChannelId { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Content { get; set; }
        public NotificationRequest(int notificationChannelId, string sender, string recipient, string content) {
            NotificationChannelId = notificationChannelId;
            Sender = sender;
            Recipient = recipient;
            Content = content;
        }
    }

    public class NotificationRequestEmail : NotificationRequest
    {
        public string Subject { get; set; }

        public NotificationRequestEmail(int notificationChannelId, string sender, string recipient, string content, string subject) : base (notificationChannelId, sender, recipient, content)
        {
            Subject = subject;
        }
    }
}
