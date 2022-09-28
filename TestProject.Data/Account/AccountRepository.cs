using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TestProject.Data.Interface.Account;
using System.Threading.Tasks;

namespace TestProject.Data.Account
{
    /// <summary>
    /// Repository for retrieving <see cref="Core.Account.Account"/>
    /// </summary>
    public sealed class AccountRepository : IAccountRepository
    {
        private readonly ZipContext _context;

        public AccountRepository(ZipContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns all <see cref="Core.Account.Account"/>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Core.Account.Account>> Get()
        {
            var data = from a in _context.Accounts
                join u in _context.Users
                    on a.UserId equals u.Id
                select new Core.Account.Account(a.Id, new Core.User.User(u.Id, u.Name, u.EmailAddress, u.MonthlySalary, u.MonthlyExpenses));


            return await data.ToListAsync();
        }
    }
}
