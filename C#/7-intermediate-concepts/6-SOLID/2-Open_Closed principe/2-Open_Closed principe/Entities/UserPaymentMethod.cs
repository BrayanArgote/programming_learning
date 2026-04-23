using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _2_Open_Closed_principe.Entities
{

    public class UserPaymentMethod
    {
        // EF requires that entites have a primary key, and when there is 
        // composite primary key, it must be handled using the Fluent API,
        // so this is a temporary solution.

        [Key]
        public int UserId { get; set; }
        public int PaymentMethodId { get; set; }
    }
}
