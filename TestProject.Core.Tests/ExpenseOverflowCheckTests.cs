using System;
using TestProject.Core.Account.Exceptions;
using TestProject.Core.Account.ValueObjects;
using Xunit;

namespace TestProject.Core.Tests
{
    public class ExpenseOverflowCheckTests
    {
        [Fact]
        public void IsExpenseOverflow_WithValidSalaryAndExpenses_ReturnsTrue()
        {
            const string userName = "testUserName";
            const string emailAddress = "testEmailAddress";
            const decimal monthlySalary = 1000;
            const decimal monthlyExpenses = 500;

            var user = new Core.User.User(userName, emailAddress, monthlySalary, monthlyExpenses);

            ExpenseOverflowCheck check = new ExpenseOverflowCheck();
            
            var result = check.IsExpenseOverflow(user);

            Assert.False(result);

        }

        [Fact]
        public void IsExpenseOverflow_WithInvalidSalaryAndExpenses_ThrowsException()
        {
            const string userName = "testUserName";
            const string emailAddress = "testEmailAddress";
            const decimal monthlySalary = 1000;
            const decimal monthlyExpenses = 5000;

            var user = new Core.User.User(userName, emailAddress, monthlySalary, monthlyExpenses);

            ExpenseOverflowCheck check = new ExpenseOverflowCheck();

            Assert.Throws<MonthlyOutflowLimitBreachException>(()=>check.IsExpenseOverflow(user));

        }

        [Fact]
        public void IsExpenseOverflow_WithNullUser_ThrowsException()
        {
            ExpenseOverflowCheck check = new ExpenseOverflowCheck();

            Assert.Throws<ArgumentNullException>(() => check.IsExpenseOverflow(null));

        }
    }
}
