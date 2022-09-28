using System;
using TestProject.Core.User.Exceptions;

namespace TestProject.Core.User
{
    public sealed class User
    {

        private readonly string _username;
        private readonly string _emailAddress;
        private readonly decimal _monthlySalary;
        private readonly decimal _monthlyExpenses;
        private readonly int _id;
        public User(string username, string emailAddress, decimal monthlySalary, decimal monthlyExpenses)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException(nameof(username));

            if (string.IsNullOrEmpty(emailAddress))
                throw new ArgumentNullException(nameof(emailAddress));

            if (monthlySalary <= 0)
                throw new InvalidAmountException("Monthly Salary must be a positive number.", monthlySalary);

            if (monthlyExpenses <= 0)
                throw new InvalidAmountException("Monthly Expenses must be a positive number.", monthlyExpenses);

            _username = username;
            _emailAddress = emailAddress;
            _monthlySalary = monthlySalary;
            _monthlyExpenses = monthlyExpenses;
        }

        public User(int id, string username, string emailAddress, decimal monthlySalary, decimal monthlyExpenses)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException(nameof(username));

            if (string.IsNullOrEmpty(emailAddress))
                throw new ArgumentNullException(nameof(emailAddress));
            
            if (monthlySalary <= 0)
                throw new InvalidAmountException("Monthly Salary must be a positive number.", monthlySalary);

            if (monthlyExpenses <= 0)
                throw new InvalidAmountException("Monthly Expenses must be a positive number.", monthlyExpenses);

            if (id <= 0)
                throw new ArgumentNullException(nameof(id));

            _id = id;
            _username = username;
            _emailAddress = emailAddress;
            _monthlySalary = monthlySalary;
            _monthlyExpenses = monthlyExpenses;
        }

        public decimal GetMonthlyOutflow()
        {
            return _monthlySalary - _monthlyExpenses;
        }

        public decimal GetMonthlySalary()
        {
            return _monthlySalary;
        }

        public decimal GetMonthlyExpenses()
        {
            return _monthlyExpenses;
        }

        public string GetUsername()
        {
            return _username;
        }

        public string GetEmailAddress()
        {
            return _emailAddress;
        }

        public int GetId()
        {
            return _id;
        }
    }
}
