using System.Collections.Generic;
using System.Linq;
using TestProject.Data.Interface.User;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestProject.Data.User
{
    /// <summary>
    /// Repository for retrieving <see cref="Core.User.User"/>
    /// </summary>
    public sealed class UserRepository : IUserRepository
    {
        private readonly ZipContext _context;

        public UserRepository(ZipContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets a single <see cref="Core.User.User"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>null if no user found</returns>
        public async Task<Core.User.User> GetById(int id)
        {
            var model = from data in _context.Users
                        where data.Id == id
                        select new Core.User.User(id, data.Name, data.EmailAddress, data.MonthlySalary, data.MonthlyExpenses);


            return await model.FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets all <see cref="Core.User.User"/>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Core.User.User>> Get()
        {
            var model = from data in _context.Users
                    select new Core.User.User(data.Id, data.Name, data.EmailAddress, data.MonthlySalary, data.MonthlyExpenses);

            return await model.ToListAsync();
        }
    }
}
