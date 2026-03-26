using _2_Open_Closed_principe.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Open_Closed_principe.Repository
{
    public class UserPaymentMethodRepository
    {
        public AppDbContext _appDbContext;
        public UserPaymentMethodRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public bool UserHasMethod(int userId, int paymentMethodId)
        {
            var b = _appDbContext.UserPaymentMethod.Any(q => q.UserId == userId && q.PaymentMethodId == paymentMethodId);

            if (b) { return true; }
            return false;
        }
    }
}
