using System.Threading.Tasks;
using System.Collections.Generic;

namespace TestProject.Data.Interface.User
{

    /// <summary>
    /// Repository for retrieving <see cref="Core.User.User"/>
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Gets a single <see cref="Core.User.User"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>null if no user found</returns>
        Task<Core.User.User> GetById(int id);

        /// <summary>
        /// Gets all <see cref="Core.User.User"/>
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Core.User.User>> Get();
    }
}
