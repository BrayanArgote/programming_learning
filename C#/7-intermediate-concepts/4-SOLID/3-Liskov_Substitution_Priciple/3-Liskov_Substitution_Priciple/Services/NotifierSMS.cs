using _3_Liskov_Substitution_Priciple.DTO;
using _3_Liskov_Substitution_Priciple.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Liskov_Substitution_Priciple.Services
{
    public class NotifierSMS : Notifier
    {
        public  NotifierSMS(NotificationLogRepository notificationLogRepository) : base(notificationLogRepository) { }


    }
}
