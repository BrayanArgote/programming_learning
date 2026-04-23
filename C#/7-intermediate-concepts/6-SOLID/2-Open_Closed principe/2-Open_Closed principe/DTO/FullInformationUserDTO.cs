using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Open_Closed_principe.DTO
{
    public class FullInformationUserDTO
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public decimal Balance { get; set; }
        public decimal Debt { get; set; }
        public List<String> ListPaymentMethods { get; set; }
    }
}
