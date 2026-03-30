using _2_Open_Closed_principe.DTO;
using _2_Open_Closed_principe.Entities;
using _2_Open_Closed_principe.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Open_Closed_principe.Services
{
    public class NequiPayment : IPayment
    {
        public PaymentRepository _paymentRepository;
        public NequiPayment(PaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public string MakePayment(PaymentRequest data)
        {
            var nequiData = (PaymentRequestNequi)data;

            if ((nequiData.Code.Length == 4 && VerifyInput(nequiData.Code) && nequiData.PhoneNumber.Length == 10 && VerifyInput(nequiData.PhoneNumber)) && nequiData.Amount > 0)
            {
                return _paymentRepository.MakePayment(nequiData.UserId, nequiData.Amount, nequiData.MethodId);
            }
            return "ERROR";
        }

        private bool VerifyInput(string input)
        {
            int result;
            if (int.TryParse(input, out result)) { return true; }
            return false;
        }
    }
}
