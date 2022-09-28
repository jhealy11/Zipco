using System;

namespace TestProject.Core.User.Exceptions
{
    [Serializable]
    public sealed class EmailAddressAlreadyExistsException : Exception
    {
        public string EmailAddress { get; }

        public EmailAddressAlreadyExistsException() { }

        public EmailAddressAlreadyExistsException(string message)
            : base(message) { }

        public EmailAddressAlreadyExistsException(string message, Exception inner)
            : base(message, inner) { }

        public EmailAddressAlreadyExistsException(string message, string emailAddress)
            : this(message)
        {
            EmailAddress = emailAddress;
        }
    }
}
