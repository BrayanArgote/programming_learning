using _3_Liskov_Substitution_Priciple.DTO;
using _3_Liskov_Substitution_Priciple.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Liskov_Substitution_Priciple.Services
{
    public class NotifierEmail : Notifier
    {
        public NotifierEmail(NotificationLogRepository notificacionLogRepository) : base(notificacionLogRepository) { }
    
        public override bool Send(NotificationRequest data)
        {
            var dataEmail = (NotificationRequestEmail)data;
            bool subjectIsValid = !string.IsNullOrEmpty(dataEmail.Subject);

            data.Content = $"SUBJECT: {dataEmail.Subject} --- CONTENT: {dataEmail.Content}";  // This is wrong, a DTO can not be modified

            bool flag = base.Send(data) && subjectIsValid;

            return flag;
        }
    }
}
