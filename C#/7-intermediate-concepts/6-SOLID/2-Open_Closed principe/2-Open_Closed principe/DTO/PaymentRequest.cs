using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Open_Closed_principe.DTO
{
    public abstract class PaymentRequest
    {
        public int UserId { get; }
        public decimal AmountEntered { get; set; }
        public int MethodId { get; }

        public PaymentRequest(int userId, int methodId)
        {
            UserId = userId;
            MethodId = methodId;
        }
    }

    public class PaymentRequestCash : PaymentRequest
    {
        public int FirstBill { get; }
        public int SecondBill { get; }
        public int ThirdBill { get; }

        public PaymentRequestCash(int userId, int methodId, int firstBill, int secondBill, int thirdBill) : base(userId, methodId)
        {
            FirstBill = firstBill;
            SecondBill = secondBill;
            ThirdBill = thirdBill;
        }

    }

    public class PaymentRequestNequi : PaymentRequest
    {
        public string PhoneNumber { get; }
        public string Code { get; }
        public decimal Amount { get; }

        public PaymentRequestNequi(int userId, decimal amount, int methodId, string phoneNumber, string code) : base(userId, methodId)
        {
            PhoneNumber = phoneNumber;
            Code = code;
            Amount = amount;
        }

    }
}
