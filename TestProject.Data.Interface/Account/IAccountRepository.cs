using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestProject.Data.Interface.Account
{
    /// <summary>
    /// Repository for retrieving <see cref="Core.Account.Account"/>
    /// </summary>
    public interface IAccountRepository
    {

        /// <summary>
        /// Returns all <see cref="Core.Account.Account"/>
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Core.Account.Account>> Get();
    }
}
