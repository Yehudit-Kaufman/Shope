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
            return await _context.Users.Include(u => u.Orders).FirstOrDefaultAsync(user => user.UserId == id);

        }
        public async Task<User> ValidateDuplicateUser(string UserName,string Password)
        {
            User checkUser = await _context.Users.FirstOrDefaultAsync(user1 => user1.UserName == UserName && user1.Password == Password);
            return checkUser;
        }
      

        public async Task<User> AddUser(User user)
        {

                _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
   

        }  




    public async Task<User> Login(string UserName, string Password)
        {
            return await _context.Users.Include(u => u.Orders).FirstOrDefaultAsync(user => user.UserName == UserName && user.Password ==Password);


        }

        public async Task<User> UpdateUser(int id, User value)
        {

            
                value.UserId = id;
                _context.Users.Update(value);
                await _context.SaveChangesAsync();
                return value;
            

        }


 



    }
}
