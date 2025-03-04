using Entite;
using Xunit;
using Repository;
using Moq;
using Moq.EntityFrameworkCore;
using DTO;
using Microsoft.AspNetCore.Authorization.Infrastructure;
namespace TestProject1
{
    public class UserReposetoryIntegrationTests : IClassFixture<DatabaseFixure>
    {
        private readonly ShopApiContext _context;
        private readonly RepositoryUser _reposetory;

        public UserReposetoryIntegrationTests(DatabaseFixure fixture)
        {
            _context = fixture.Context;
            _reposetory = new RepositoryUser(_context);
        }

        [Fact]
        public async Task Get_ShouldReturnUser_WhenUserExists()
        {
            var user = new User { UserName = "test@example.com", Password = "password123", FirstName = "John", LastName = "Doe" };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();


            var retrievedUser = await _reposetory.GetUserById(user.UserId);

            Assert.NotNull(retrievedUser);
            Assert.Equal(user.UserName, retrievedUser.UserName);
            Assert.Equal(user.FirstName, retrievedUser.FirstName);
            Assert.Equal(user.LastName, retrievedUser.LastName);
        }

        [Fact]
        public async Task Get_ShouldReturnNull_WhenUserDoesNotExist()
        {
            // Act
            //var retrievedUser = await _context.Users.FindAsync(-1); // מזהה לא קיים
            var retrievedUser = await _reposetory.GetUserById(-1);
            // Assert
            Assert.Null(retrievedUser);
        }

        [Fact]

        public async Task Login_InvalidPasswordReturnsNull()
        {
            // Arrange
            var user = new User { UserName = "test@example.com", Password = "password123", FirstName = "John", LastName = "Doe" };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Act
            var result = await _reposetory.Login(user.UserName, "wrongpassword");

            // Assert
            Assert.Null(result);
        }
     

       
        
        [Fact]
        public async Task Login_InvalidEmailReturnsNull()
        {
            // Arrange
            var user = new User { FirstName = "aa", LastName = "bb", UserName = "Tz@123cvv", Password = "secure123" };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Act
            var result = await _reposetory.Login("wrong@email.com", user.Password);

            // Assert
            Assert.Null(result);
        }
        [Fact]
        public async Task Post_ShouldAddUser_WhenUserIsValid()
        {
            // Arrange
            var user = new User { UserName = "newuser@example.com", Password = "securepassword",FirstName="aa",LastName="bb"};

            // Act
            // var addedUser = await _context.Users.AddAsync(user);
            var addedUser = await _reposetory.AddUser(user);


            //await _context.SaveChangesAsync();

            // Assert
            Assert.NotNull(addedUser);
            Assert.Equal(user.UserName, addedUser.UserName);
            Assert.True(addedUser.UserId > 0); // נניח שהמזהה יוקצה אוטומטית
        }


    }
}



