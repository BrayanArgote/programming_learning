using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _2_Open_Closed_principe.Entities
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public  User User { get; set; }
        public decimal Amount { get; set; }
        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime Date { get; set; }
    }
}
