using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Entite;
using Zxcvbn;


namespace Service
{
    public class ServiceUser : IServiceUser

    {

        IRepositoryUser repository;
        public ServiceUser(IRepositoryUser _repositoryUser)
        {
            repository = _repositoryUser;
        }

 
        public async Task<User> GetUserById(int id)
        {
            return await repository.GetUserById(id);

        }

        public async Task<User> AddUser(User user)
        {
            int passwordStrength = CheckPassword(user.Password);
            if (passwordStrength >= 2)
                return await repository.AddUser(user);
            else
                return null;
        }
        public async Task<User> Login(string UserName, string Password)
        {
            return await repository.Login(UserName, Password);
        }

        public async Task<User> UpdateUser(int id, User user)
        {
            if (CheckPassword(user.Password) < 3)
                throw new Exception("Password is not strong enough");
 ;
            return await repository.UpdateUser(id, user);
        }
        public int CheckPassword(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }

    }
}
