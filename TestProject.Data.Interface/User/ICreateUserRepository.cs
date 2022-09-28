using System.Threading.Tasks;

namespace TestProject.Data.Interface.User
{
    /// <summary>
    /// Repository for creating a new <see cref="Core.User.User"/>
    /// </summary>
    public interface ICreateUserRepository
    {
        /// <summary>
        /// Persists a new <see cref="Core.User.User"/>.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task CreateUser(Core.User.User user);
        /// <summary>
        /// Gets a <see cref="Core.User.User"/> by email address.
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns>Returns null if not found</returns>
        Task<Core.User.User> GetUserByEmailAddress(string emailAddress);
    }
}
