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
        private readonly AppDbContext _appDbContext;
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

        public string MakePayment(int UserId, decimal amountEntered, int methodId)
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
                new SqlParameter("@Method", methodId),
                response,
                responseCode);

            switch (responseCode.Value)
            {
                case 201: return $"--- Payment Successful ---\nChange: {response.Value}";
                case 202: return $"--- Payment Successful ---\nOutStanding balance: {response.Value}";
                case 400: return "*** You don't have sufficient balance or the amount entered is invalid ***";
                case 404: return "*** User was not found ***"; ;
                default: return "ERROR";
            }
            ;

        }

    }
}
