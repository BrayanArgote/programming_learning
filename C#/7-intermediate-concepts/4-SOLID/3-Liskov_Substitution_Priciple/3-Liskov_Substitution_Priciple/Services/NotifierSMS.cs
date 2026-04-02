using _3_Liskov_Substitution_Priciple.DTO;
using _3_Liskov_Substitution_Priciple.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Liskov_Substitution_Priciple.Services
{
    public class NotifierSMS : Notifier
    {
        private readonly NotificationLogRepository _notificationLogRepository;

        public  NotifierSMS(NotificationLogRepository notificationLogRepository) : base(notificationLogRepository) { }

        public override bool Send(NotificationRequest data)
        {
            var smsData = (NotificationRequestSms)data;

            return base.Send(smsData);
        }

    }
}
