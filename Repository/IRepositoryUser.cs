using Entite;

namespace Repository
{
    public interface IRepositoryUser
    {
        Task<User> AddUser(User user);
        Task<User> GetUserById(int id);
        Task<User> Login(string UserName, string Password);
        Task<User> UpdateUser(int id, User value);
        Task<User> ValidateDuplicateUser(string UserName, string Password);
    }
}