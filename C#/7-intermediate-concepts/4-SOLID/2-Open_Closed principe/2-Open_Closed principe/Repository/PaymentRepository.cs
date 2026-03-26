using _2_Open_Closed_principe.DataBase;
using _2_Open_Closed_principe.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Open_Closed_principe.Repository
{
    public class PaymentRepository
    {
        public AppDbContext _appDbContext;
        public PaymentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Payment> GetAllPayments()
        {
            return _appDbContext.Payment
                .Include(q => q.User)
                .Include(q => q.PaymentMethod)
                .ToList();
        }

        public string MakePayment(int UserId, decimal amountEntered, string method)
        {
            var response = new SqlParameter("@Response", System.Data.SqlDbType.Decimal)
            {
                Direction = System.Data.ParameterDirection.Output
            };

            var responseCode = new SqlParameter("@ResponseCode", System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };

            _appDbContext.Database.ExecuteSqlRaw(
                "EXEC sp_ProcessPayment @UserId, @AmountEntered, @Method, @Response OUTPUT, @ResponseCode OUTPUT",
                new SqlParameter("@UserId", UserId),
                new SqlParameter("@AmountEntered", amountEntered),
                new SqlParameter("@Method", method),
                response,
                responseCode);

            if (responseCode.Value == "404")
            {
                return"*** User was not found ***";
            }
            else if(responseCode.Value == "400")
            {
                return "*** You don't have sufficient balance or the amount entered is invalid ***";
            }
            return "--- Sucessfully ---";
        }

    }
}
