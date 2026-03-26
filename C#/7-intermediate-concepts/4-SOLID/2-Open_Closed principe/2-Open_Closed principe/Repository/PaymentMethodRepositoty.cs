using _2_Open_Closed_principe.DataBase;
using _2_Open_Closed_principe.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Open_Closed_principe.Repository
{
    public class PaymentMethodRepositoty
    {
        public AppDbContext _appDbContext;
        public PaymentMethodRepositoty(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }

        public List<PaymentMethod> GetAll()
        {
            return _appDbContext.PaymentMethod.ToList();
        }
    }
}
