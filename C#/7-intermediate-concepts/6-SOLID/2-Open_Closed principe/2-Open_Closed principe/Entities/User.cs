using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _2_Open_Closed_principe.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FullName { get; set; }
        public decimal Balance { get; set; }
        public decimal Debt { get; set; }

    }
}
