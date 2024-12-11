using Entite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Repository
{


    public class RepositoryUser : IRepositoryUser
    {
        ShopApiContext _context;
        public RepositoryUser(ShopApiContext shopApiContext)
        {
            _context = shopApiContext;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.UserId == id);
  
            

        }

        public async Task<User> AddUser(User user)
        {
            //int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            //user.UserId = numberOfUsers + 1;
            _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;

        }

        public async Task<User> Login(string UserName, string Password)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.UserName == UserName && user.Password ==Password);


        }

        public async Task UpdateUser(int id, User value)//return user
        {
            _context.Users.Update(value);
            await _context.SaveChangesAsync();
        }






    }
}
