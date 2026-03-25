using _2_Open_Closed_principe.DataBase;
using _2_Open_Closed_principe.Entities;
using Microsoft.EntityFrameworkCore;
using System;
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

        public List<User> GetAllUsers()
        {
            return _appDbContext.User.ToList();
        }

        public User GetUserById(int id)
        {
            return _appDbContext.User.FirstOrDefault(q => q.UserId == id);
        }

    }
}
