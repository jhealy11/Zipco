using System;

namespace TestProject.Core.Account.Exceptions
{
    [Serializable]
    public class UserDoesNotExistException : Exception
    {
        public int UserId;
        
        public UserDoesNotExistException() { }

        public UserDoesNotExistException(string message)
            : base(message) { }

        public UserDoesNotExistException(string message, Exception inner)
            : base(message, inner) { }

        public UserDoesNotExistException(string message, int userId)
            : this(message)
        {
            UserId = userId;
        }
    }
}
