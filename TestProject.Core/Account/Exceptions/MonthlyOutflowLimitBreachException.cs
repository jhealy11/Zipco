using System;


namespace TestProject.Core.Account.Exceptions
{
    [Serializable]
    public sealed class MonthlyOutflowLimitBreachException : Exception
    {
        public decimal MonthlyOutflow;
        public MonthlyOutflowLimitBreachException() { }

        public MonthlyOutflowLimitBreachException(string message)
            : base(message) { }

        public MonthlyOutflowLimitBreachException(string message, Exception inner)
            : base(message, inner) { }

        public MonthlyOutflowLimitBreachException(string message, decimal montlyOutflow)
            : this(message)
        {
            MonthlyOutflow = montlyOutflow;
        }
    }
}
