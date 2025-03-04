using Entite;

namespace Service
{
    public interface IServiceUser
    {
        Task<User> AddUser(User user);
        Task<User> GetUserById(int id);
        Task<User> Login(string UserName, string Password);
        Task<User> UpdateUser(int id, User value);
        public int CheckPassword(string password);
        Task<User> ValidateDuplicateUser(string UserName, string Password);
    }
}