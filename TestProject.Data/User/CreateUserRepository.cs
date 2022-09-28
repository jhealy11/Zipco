using TestProject.Data.Interface.User;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestProject.Data.User
{
    /// <summary>
    /// Repository for creating a new <see cref="Core.User.User"/>
    /// </summary>
    public sealed class CreateUserRepository : ICreateUserRepository
    {
        private readonly ZipContext _context;
        public CreateUserRepository(ZipContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Persists a new <see cref="Core.User.User"/>.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task CreateUser(Core.User.User user)
        {
            await _context.Users.AddAsync(new Model.User { Name = user.GetUsername(), EmailAddress = user.GetEmailAddress(), MonthlyExpenses = user.GetMonthlyExpenses(), MonthlySalary = user.GetMonthlySalary()});

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets a <see cref="Core.User.User"/> by email address.
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns>Returns null if not found</returns>
        public async Task<Core.User.User> GetUserByEmailAddress(string emailAddress)
        {
            var result =  await _context.Users.FirstOrDefaultAsync(m => m.EmailAddress == emailAddress);
            return result == null ? null : new Core.User.User(result.Name, result.EmailAddress, result.MonthlySalary, result.MonthlyExpenses);
        }
    }
}
