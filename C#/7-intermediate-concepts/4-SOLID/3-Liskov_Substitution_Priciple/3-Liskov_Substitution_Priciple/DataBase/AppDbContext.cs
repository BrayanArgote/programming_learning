using _3_Liskov_Substitution_Priciple.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Liskov_Substitution_Priciple.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options){}

        public DbSet<NotificationLog> NotificationLog { get; set; }
        public DbSet<NotificationChannel> NotificationChannel { get; set; }

    }
}
