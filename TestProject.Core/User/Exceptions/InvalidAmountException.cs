using System;

namespace TestProject.Core.User.Exceptions
{
    [Serializable]
    public  class InvalidAmountException : Exception
    {
        public decimal Amount{ get; }

        public InvalidAmountException() { }

        public InvalidAmountException(string message)
            : base(message) { }

        public InvalidAmountException(string message, Exception inner)
            : base(message, inner) { }

        public InvalidAmountException(string message, decimal amount)
            : this(message)
        {
            Amount = amount;
        }
    }
}
