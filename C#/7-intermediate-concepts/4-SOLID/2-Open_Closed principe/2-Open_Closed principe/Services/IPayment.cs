using _2_Open_Closed_principe.DTO;
using _2_Open_Closed_principe.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Open_Closed_principe.Services
{
    public interface IPayment
    {
        string MakePayment(PaymentRequest request);
    }
}