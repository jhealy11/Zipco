using TestProject.Data.Interface.Account;
using System.Threading.Tasks;

namespace TestProject.Data.Account
{
    /// <summary>
    /// Repository for creating a new <see cref="Core.Account.Account"/>
    /// </summary>
    public sealed class CreateAccountRepository : ICreateAccountRepository
    {

        private readonly ZipContext _context;

        public CreateAccountRepository(ZipContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Persists a new <see cref="Core.Account.Account"/>.
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public async Task CreateAccount(Core.Account.Account account)
        {
            var data = new Model.Account
            {
                UserId = account.GetUserId()
            };
            await _context.Accounts.AddAsync(data);

            await _context.SaveChangesAsync();
        }
    }
}
