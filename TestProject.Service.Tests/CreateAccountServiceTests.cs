using System;
using Xunit;
using System.Threading.Tasks;
namespace TestProject.Service.Tests
{
    public class CreateAccountServiceTests : IClassFixture<CreateAccountServiceFixture>
    {

        private readonly CreateAccountServiceFixture _fixture;

        public CreateAccountServiceTests(CreateAccountServiceFixture fixture)
        {
            _fixture = fixture;
        }


        [Fact]
        public void CreateAccount_WithGivenAccount_CreatesAccount()
        {
            const int userId = 1;
            Core.Account.Account account = new Core.Account.Account(userId);

            _fixture.CreateAccountService.CreateAccount(account);


        }

        [Fact]
        public void CreateAccount_WithNullAccount_ThrowsException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(()=>_fixture.CreateAccountService.CreateAccount(null));
        }

        [Fact]
        public void CreateAccount_WithValidAccount_CreatesAccount()
        {
            const int userId = 1;

            const string userName = "testUserName";
            const string emailAddress = "testEmailAddress";
            const decimal monthlySalary = 1000;
            const decimal monthlyExpenses = 500;

            var user = new Core.User.User(userName, emailAddress, monthlySalary, monthlyExpenses);

            Core.Account.Account account = new Core.Account.Account(userId);


            _fixture.MockUserRepository.Setup(m => m.GetById(userId)).Returns(Task.FromResult(user));


             _fixture.CreateAccountService.CreateAccount(account);
        }
    }
}
