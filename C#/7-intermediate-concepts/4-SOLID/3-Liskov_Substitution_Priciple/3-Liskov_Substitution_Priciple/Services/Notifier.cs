using _3_Liskov_Substitution_Priciple.DTO;
using _3_Liskov_Substitution_Priciple.Entities;
using _3_Liskov_Substitution_Priciple.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Liskov_Substitution_Priciple.Services
{
    public class Notifier
    {
        private readonly NotificationLogRepository _notificationLogRepository;
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Content { get; set; }

        public Notifier(NotificationLogRepository notificationLogRepository)
        {
            _notificationLogRepository = notificationLogRepository;
        }
        public virtual bool Send(NotificationRequest data)
        {
            bool flag;
            if (string.IsNullOrEmpty(data.Sender) || string.IsNullOrEmpty(data.Recipient) || string.IsNullOrEmpty(data.Content)) { flag = false; }
            else {  flag = true; }

            var notificationLog = new NotificationLog
            {
                NotificationChannelId = data.NotificationChannelId,
                Sender = data.Sender,
                Recipient = data.Recipient,
                Content = data.Content,
            };

            _notificationLogRepository.Add(notificationLog);

            return flag;

        }
    }
}
