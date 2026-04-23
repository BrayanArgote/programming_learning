using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _3_Liskov_Substitution_Priciple.Entities
{
    public class NotificationLog
    {
        public int Id { get; set; }
        public int NotificationChannelId { get; set; }

        public NotificationChannel NotificationChannel { get; set; }

        [MaxLength(20)]
        public string Sender { get; set; }

        [MaxLength(20)]
        public string Recipient { get; set; }

        [MaxLength(50)]
        public string Content { get; set; }
    }
}
