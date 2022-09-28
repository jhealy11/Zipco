using System;
using TestProject.Core.User.Exceptions;
using TestProject.Data.Interface.User;
using TestProject.Service.Interface.User;
using System.Threading.Tasks;

namespace TestProject.Service.User
{
    /// <summary>
    /// Orchestrates the creation of a new <see cref="Core.User.User"/>.
    /// </summary>
    public sealed class CreateUserService : ICreateUserService
    {
        private readonly ICreateUserRepository _createUserRepository;

        public CreateUserService(ICreateUserRepository createUserRepository)
        {
            _createUserRepository = createUserRepository;
        }


        /// <summary>
        /// Creates a new <see cref="Core.User.User"/>. Checks for uniqueness of the new user with email address as a property.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task CreateNewUser(Core.User.User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));


            var existingUser = await _createUserRepository.GetUserByEmailAddress(user.GetEmailAddress());
            if (existingUser != null)
                throw new EmailAddressAlreadyExistsException("User with email address already exists");

            await _createUserRepository.CreateUser(user);

        }
    }
}
