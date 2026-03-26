using _2_Open_Closed_principe.DataBase;
using _2_Open_Closed_principe.DTO;
using _2_Open_Closed_principe.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _2_Open_Closed_principe.Repository
{
    public class UserRepository
    {
        public readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<FullInformationUserDTO> GetAll()
        {
            var query = from u in _appDbContext.User
                        join upm in _appDbContext.UserPaymentMethod on u.UserId equals upm.UserId into firstGroup
                        from upm in firstGroup.DefaultIfEmpty()

                        join pm in _appDbContext.PaymentMethod on upm.PaymentMethodId equals pm.PaymentMethodId into secondGroup
                        from pm in secondGroup.DefaultIfEmpty()
                        group pm by new { u.UserId, u.FullName, u.Balance, u.Debt } into r
                        select new FullInformationUserDTO
                        {
                            UserId = r.Key.UserId,
                            FullName = r.Key.FullName,
                            Balance = r.Key.Balance,
                            Debt = r.Key.Debt,
                            ListPaymentMethods = r.Select(q => q.Type).ToList(),
                        };

            return query.ToList();
        }

        public User GetUserById(int id)
        {
            return _appDbContext.User.FirstOrDefault(q => q.UserId == id);
        }


        public List<PaymentMethod> GetPaymentMethodsUser(int id)
        {
            var query = from pm in _appDbContext.PaymentMethod
                        join upm in _appDbContext.UserPaymentMethod on pm.PaymentMethodId equals upm.PaymentMethodId
                        where upm.UserId == id
                        select new PaymentMethod
                        {
                            PaymentMethodId = pm.PaymentMethodId,
                            Type = pm.Type
                        };
                        
            return query.ToList();
        }
        

    }
}
