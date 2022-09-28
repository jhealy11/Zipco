using System.Threading.Tasks;

namespace TestProject.Service.Interface.User
{

    /// <summary>
    /// Orchestrates the creation of a new <see cref="Core.User.User"/>.
    /// </summary>
    public interface ICreateUserService
    {
        /// <summary>
        /// Creates a new <see cref="Core.User.User"/>. Checks for uniqueness of the new user with email address as a property.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task CreateNewUser(Core.User.User user);
    }
}
