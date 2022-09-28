using System;
using TestProject.Core.User.Exceptions;
using Xunit;
using System.Threading.Tasks;

namespace TestProject.Service.Tests
{
    public class CreateUserServiceTests : IClassFixture<CreateUserServiceFixture>
    {
        private readonly CreateUserServiceFixture _fixture;

        public CreateUserServiceTests(CreateUserServiceFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void CreateNewUser_WithValidUser_CreatesUser()
        {
            var user = new Core.User.User("testUserName", "testEmail", 2000, 3000);
            _fixture.MockRepository.Setup(m => m.GetUserByEmailAddress("testEmail"));

            _fixture.CreateUserService.CreateNewUser(user);
        }

        [Fact]
        public void CreateNewUser_WithDuplicateEmailAddress_ThrowsException()
        {
            var user = new Core.User.User("testUserName", "testEmail", 2000, 3000);
            _fixture.MockRepository.Setup(m => m.GetUserByEmailAddress("testEmail")).Returns(Task.FromResult(new Core.User.User("testUserName", "testEmail", 2000, 3000)));

            Assert.ThrowsAsync<EmailAddressAlreadyExistsException>(()=> _fixture.CreateUserService.CreateNewUser(user));
        }


        [Fact]
        public void CreateNewUser_WithNullUser_ThrowsArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(()=>_fixture.CreateUserService.CreateNewUser(null));
        }
    }
}
