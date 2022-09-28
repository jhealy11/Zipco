
using System;
using TestProject.Service.Interface.Account;
using TestProject.Data.Interface.Account;
using TestProject.Data.Interface.User;
using System.Threading.Tasks;

namespace TestProject.Service.Account
{
    /// <summary>
    /// Orchestrates the creation a new new <see cref="Core.Account.Account"></see> for a <see cref="Core.User.User"/>
    /// </summary>
    public sealed class CreateAccountService : ICreateAccountService
    {
        private readonly ICreateAccountRepository _createAccountRepository;
        private readonly IUserRepository _userRepository;

        public CreateAccountService(ICreateAccountRepository createAccountRepository, IUserRepository userRepository)
        {
            _createAccountRepository = createAccountRepository;
            _userRepository = userRepository;
        }

        /// <summary>
        ///     Creates a new <see cref="Core.Account.Account " />. Checks to ensure <see cref="Core.User.User" /> exists and
        ///     checks rules on account overflow limits.
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public async Task CreateAccount(Core.Account.Account account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            var user = await _userRepository.GetById(account.GetUserId());
            if (user == null)
                throw new Core.Account.Exceptions.UserDoesNotExistException(
                    "user not found, when trying to create account", account.GetUserId());

            Core.Account.ValueObjects.ExpenseOverflowCheck expenseOverflowCheck =
                new Core.Account.ValueObjects.ExpenseOverflowCheck();
            if (!expenseOverflowCheck.IsExpenseOverflow(user))
            {
                await _createAccountRepository.CreateAccount(account);
            }

        }
    }
}
