using _3_Liskov_Substitution_Priciple.DataBase;
using _3_Liskov_Substitution_Priciple.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Liskov_Substitution_Priciple.Repository
{
    public class NotificationLogRepository
    {
        private readonly AppDbContext _appDbContext;
        public NotificationLogRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<NotificationLog> GetAll()
        {
            return _appDbContext.NotificationLog
                .Include(q => q.NotificationChannel)
                .ToList();
        }

        public void Add(NotificationLog notification) {
            _appDbContext.NotificationLog.Add(notification);
            _appDbContext.SaveChanges();
        }

    }
}
