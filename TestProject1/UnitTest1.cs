using Entite;
using Repository;
using Moq;
using Moq.EntityFrameworkCore;
using DTO;
using Microsoft.AspNetCore.Authorization.Infrastructure;
namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var user = new User { UserName = "y0504130776@gmail.com", Password = "214982472" };
            var mokContext = new Mock<ShopApiContext>();
            var users = new List<User>() { user };
            mokContext.Setup(x => x.Users).ReturnsDbSet(users);
            var userRepository = new RepositoryUser(mokContext.Object);
            var result = await userRepository.Login(user.UserName,user.Password);
            Assert.Equal(user, result);
            
        }
      
    }
}