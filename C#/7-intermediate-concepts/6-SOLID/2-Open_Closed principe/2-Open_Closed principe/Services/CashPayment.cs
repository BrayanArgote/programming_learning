using _2_Open_Closed_principe.DataBase;
using _2_Open_Closed_principe.DTO;
using _2_Open_Closed_principe.Repository;
using _2_Open_Closed_principe.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Open_Closed_principe.Services
{
    public class CashPayment : IPayment
    {
        public PaymentRepository _paymentRepository;
        public CashPayment(PaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public string MakePayment(PaymentRequest data)
        {
            var cashData = (PaymentRequestCash)data;
            var amount = CashToPayment(cashData.FirstBill, cashData.SecondBill, cashData.ThirdBill);
            if (amount != 0)
            {
                return _paymentRepository.MakePayment(data.UserId, amount, data.MethodId);
            }
            return "ERROR";
        }

        private decimal CashToPayment(int firstBill, int secondBill, int thirdBill)
        {
            if (ValidateBill(firstBill) && ValidateBill(secondBill) && ValidateBill(thirdBill))
            {
                return (decimal)(firstBill + secondBill + thirdBill);
            }
            return 0;
        }

        private bool ValidateBill(int bill)
        {
            if (bill == 1 || bill == 2 || bill == 5 || bill == 10 || bill == 20 || bill == 50 || bill == 100)
            {
                return true;
            }
            return false;
        }
    }
}

