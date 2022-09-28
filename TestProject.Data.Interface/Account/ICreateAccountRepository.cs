
using System.Threading.Tasks;

namespace TestProject.Data.Interface.Account
{

    /// <summary>
    /// Repository for creating a new <see cref="Core.Account.Account"/>
    /// </summary>
    public interface ICreateAccountRepository
    {
        /// <summary>
        /// Persists a new <see cref="Core.Account.Account"/>.
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        Task CreateAccount(Core.Account.Account account);

    }
}
