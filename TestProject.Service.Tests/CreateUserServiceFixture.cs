using System;
using TestProject.Service.Interface.User;
using TestProject.Service.User;
using TestProject.Data.Interface.User;
using Moq;

namespace TestProject.Service.Tests
{
    public class CreateUserServiceFixture
    {
        public ICreateUserService CreateUserService = null;
        public Moq.Mock<ICreateUserRepository> MockRepository = null;
        public CreateUserServiceFixture()
        {
            MockRepository = new Moq.Mock<ICreateUserRepository>();
            
            CreateUserService = new CreateUserService(MockRepository.Object);        
        }
    }
}
