using System.Threading.Tasks;

namespace TestProject.Service.Interface.Account
{
    /// <summary>
    ///     Orchestrates the creation a new new <see cref="Core.Account.Account"></see> for a <see cref="Core.User.User" />
    /// </summary>
    public interface ICreateAccountService
    {
        /// <summary>
        ///     Creates a new <see cref="Core.Account.Account " />. Checks to ensure <see cref="Core.User.User" /> exists and
        ///     checks rules on account overflow limits.
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        Task CreateAccount(Core.Account.Account account);
    }
}