using System;
using Xunit;

namespace TestProject.Core.Tests
{
    public class AccountTests
    {
        [Fact]
        public void Constructor_WithValidArguments_CreatesAccount()
        {
            const int userId = 1;
            
            Account.Account account = new Account.Account(userId);

            Assert.NotNull(account);
        }

        [Fact]
        public void Constructor_WithInvalidArguments_ThrowsException()
        {
            const int userId = -1;

            Assert.Throws<ArgumentNullException>(()=>new Account.Account(userId));

        }


        [Fact]
        public void ConstructorWithUser_WithValidArguments_CreatesAccount()
        {
            const int id = 1;
            Core.User.User testUser = new User.User(1, "testUsername", "testEmailAddress", 100, 50);
            Account.Account account = new Account.Account(id, testUser);

            Assert.NotNull(account);
        }

        [Fact]
        public void ConstructorWithUser_WithInvalidId_ThrowsException()
        {
            const int id = -1;
            Core.User.User testUser = new User.User(1, "testUsername", "testEmailAddress", 100, 50);
            Assert.Throws<ArgumentNullException>(()=>new Account.Account(id, testUser));

        }

        [Fact]
        public void ConstructorWithUser_WithNullUser_ThrowsException()
        {
            const int id = 1;
            
            Assert.Throws<ArgumentNullException>(()=>new Account.Account(id, null));

        }
        

        [Fact]
        public void GetId_WithValidArguments_ReturnsId()
        {
            const int id = 1;
            Core.User.User testUser = new User.User(1, "testUsername", "testEmailAddress", 100, 50);
            const int expectedId = 1;
            
            Account.Account account = new Account.Account(id, testUser);


            var result = account.GetId();

            Assert.Equal(expectedId, result);
        }
        
        [Fact]
        public void GetUser_WithValidArguments_ReturnsId()
        {
            const int id = 1;
            Core.User.User testUser = new User.User(1, "testUsername", "testEmailAddress", 100, 50);
            Core.User.User expectedTestUser = new User.User(1, "testUsername", "testEmailAddress", 100, 50);

            Account.Account account = new Account.Account(id, testUser);


            var result = account.GetUser();

            Assert.Equal(expectedTestUser.GetId(), result.GetId());
        }

        [Fact]
        public void GetUserId_WithValidArguments_ReturnsUserId()
        {
            const int userId = 1;
            const int expectedUserId = 1;

            Account.Account account = new Account.Account(userId);


            var result = account.GetUserId();

            Assert.Equal(expectedUserId, result);
        }
    }
}
