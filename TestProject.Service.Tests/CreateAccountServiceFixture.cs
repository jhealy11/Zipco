
using TestProject.Data.Interface.Account;
using TestProject.Service.Interface.Account;
using TestProject.Service.Account;
using TestProject.Data.Interface.User;

namespace TestProject.Service.Tests
{
    public class CreateAccountServiceFixture
    {
        public ICreateAccountService CreateAccountService = null;
        public Moq.Mock<ICreateAccountRepository> MockRepository = null;
        public Moq.Mock<IUserRepository> MockUserRepository = null;
        public CreateAccountServiceFixture()
        {
            MockRepository = new Moq.Mock<ICreateAccountRepository>();
            MockUserRepository = new Moq.Mock<IUserRepository>();

            CreateAccountService = new CreateAccountService(MockRepository.Object, MockUserRepository.Object);
        }
    }
}
