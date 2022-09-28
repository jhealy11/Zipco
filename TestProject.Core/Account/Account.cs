
using System;

namespace TestProject.Core.Account
{
    public sealed class Account
    {
        private readonly int _userId;
        private readonly int _id;

        private readonly Core.User.User _user;
        public Account(int userId)
        {
            if (userId <= 0)
                throw new ArgumentNullException(nameof(userId));

            _userId = userId;
        }

        public Account(int id, Core.User.User user)
        {
            if (id <= 0)
                throw new ArgumentNullException(nameof(id));

            if(user == null)
                throw new ArgumentNullException(nameof(user));

            _id = id;
            _user = user;
        }
        

        public int GetUserId()
        {
            return _userId;
        }
        
        public int GetId()
        {
            return _id;
        }

        public User.User GetUser()
        {
            return _user;
        }
    }
}
