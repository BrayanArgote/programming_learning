using _3_Liskov_Substitution_Priciple.DataBase;
using _3_Liskov_Substitution_Priciple.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Liskov_Substitution_Priciple.Repository
{
    public class NotificationChannelRepository
    {
        private readonly AppDbContext _appDbContext;

        public NotificationChannelRepository (AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<NotificationChannel> GetAll()
        {
            return _appDbContext.NotificationChannel.ToList();
        }
    }
}
