using System;
using TestProject.Core.User.Exceptions;
using Xunit;

namespace TestProject.Core.Tests
{
    public class UserTests
    {
        [Fact]
        public void Constructor_WithGivenArguments_CreatesUser()
        {
            const string userName = "testUserName";
            const string emailAddress = "testEmailAddress";
            const decimal monthlySalary= 1000;
            const decimal monthlyExpenses = 500;

            var user = new User.User(userName, emailAddress, monthlySalary, monthlyExpenses);

            Assert.NotNull(user);
        }

        [Fact]
        public void Constructor_WithNullUserName_ThrowsException()
        {
            const string userName = null;
            const string emailAddress = "testEmailAddress";
            const decimal monthlySalary = 1000;
            const decimal monthlyExpenses = 500;

            Assert.Throws<ArgumentNullException>(()=>new User.User(userName, emailAddress, monthlySalary, monthlyExpenses));

        }

        [Fact]
        public void Constructor_WithNullEmailAddress_ThrowsException()
        {
            const string userName = "testUserName";
            const string emailAddress = null;
            const decimal monthlySalary = 1000;
            const decimal monthlyExpenses = 500;

            Assert.Throws<ArgumentNullException>(() => new User.User(userName, emailAddress, monthlySalary, monthlyExpenses));

        }

        [Fact]
        public void Constructor_WithInvalidMonthlySalary_ThrowsException()
        {
            const string userName = "testUserName";
            const string emailAddress = "testEmailAddress";
            const decimal monthlySalary = -1000;
            const decimal monthlyExpenses = 500;

            Assert.Throws<InvalidAmountException>(() => new User.User(userName, emailAddress, monthlySalary, monthlyExpenses));

        }

        [Fact]
        public void Constructor_WithInvalidMonthlyExpenses_ThrowsException()
        {
            const string userName = "testUserName";
            const string emailAddress = "testEmailAddress";
            const decimal monthlySalary = 1000;
            const decimal monthlyExpenses = -500;

            Assert.Throws<InvalidAmountException>(() => new User.User(userName, emailAddress, monthlySalary, monthlyExpenses));

        }

        [Fact]
        public void ConstructorWithId_WithGivenArguments_CreatesUser()
        {
            const int id = 1;
            const string userName = "testUserName";
            const string emailAddress = "testEmailAddress";
            const decimal monthlySalary = 1000;
            const decimal monthlyExpenses = 500;

            var user = new User.User(id, userName, emailAddress, monthlySalary, monthlyExpenses);

            Assert.NotNull(user);
        }

        [Fact]
        public void ConstructorWithId_WithNullUserName_ThrowsException()
        {
            const int id = 1;
            const string userName = null;
            const string emailAddress = "testEmailAddress";
            const decimal monthlySalary = 1000;
            const decimal monthlyExpenses = 500;

            Assert.Throws<ArgumentNullException>(() => new User.User(id, userName, emailAddress, monthlySalary, monthlyExpenses));

        }

        [Fact]
        public void ConstructorWithId_WithNullEmailAddress_ThrowsException()
        {
            const int id = 1;
            const string userName = "testUserName";
            const string emailAddress = null;
            const decimal monthlySalary = 1000;
            const decimal monthlyExpenses = 500;

            Assert.Throws<ArgumentNullException>(() => new User.User(id, userName, emailAddress, monthlySalary, monthlyExpenses));

        }

        [Fact]
        public void ConstructorWithId_WithInvalidId_ThrowsException()
        {
            const int id = -1;
            const string userName = "testUserName";
            const string emailAddress = "testEmailAddress";
            const decimal monthlySalary = 1000;
            const decimal monthlyExpenses = 500;

            Assert.Throws<ArgumentNullException>(() => new User.User(id, userName, emailAddress, monthlySalary, monthlyExpenses));

        }
        

        [Fact]
        public void GetMonthlyOutflow_WithValidUser_ReturnsCorrectMonthlyOutflow()
        {
            const string userName = "testUserName";
            const string emailAddress = "testEmailAddress";
            const decimal monthlySalary = 1000;
            const decimal monthlyExpenses = 400;

            const decimal monthlyOutflow = 600;

            var user = new User.User(userName, emailAddress, monthlySalary, monthlyExpenses);

            var result = user.GetMonthlyOutflow();

            Assert.Equal(monthlyOutflow, result);
        }
        
        
        [Fact]
        public void GetMonthlySalary_WithValidUser_ReturnsCorrectMonthlySalary()
        {
            const string userName = "testUserName";
            const string emailAddress = "testEmailAddress";
            const decimal monthlySalary = 1000;
            const decimal monthlyExpenses = 400;

            const decimal expectedMonthlySalary = 1000;

            var user = new User.User(userName, emailAddress, monthlySalary, monthlyExpenses);

            var result = user.GetMonthlySalary();

            Assert.Equal(expectedMonthlySalary, result);
        }
        
        [Fact]
        public void GetMonthlyExpenses_WithValidUser_ReturnsCorrectMonthlyExpenses()
        {
            const string userName = "testUserName";
            const string emailAddress = "testEmailAddress";
            const decimal monthlySalary = 1000;
            const decimal monthlyExpenses = 400;

            const decimal expectedMonthlyExpenses = 400;

            var user = new User.User(userName, emailAddress, monthlySalary, monthlyExpenses);

            var result = user.GetMonthlyExpenses();

            Assert.Equal(expectedMonthlyExpenses, result);
        }
        
        [Fact]
        public void GetUsername_WithValidUser_ReturnsCorrectUsername()
        {
            const string userName = "testUserName";
            const string emailAddress = "testEmailAddress";
            const decimal monthlySalary = 1000;
            const decimal monthlyExpenses = 400;

            const string expectedUserName = "testUserName";

            var user = new User.User(userName, emailAddress, monthlySalary, monthlyExpenses);

            var result = user.GetUsername();

            Assert.Equal(expectedUserName, result);
        }
        
        [Fact]
        public void GetEmailAddress_WithValidUser_ReturnsCorrectEmailAddress()
        {
            const string userName = "testUserName";
            const string emailAddress = "testEmailAddress";
            const decimal monthlySalary = 1000;
            const decimal monthlyExpenses = 400;

            const string expectedEmailAddress = "testEmailAddress";

            var user = new User.User(userName, emailAddress, monthlySalary, monthlyExpenses);

            var result = user.GetEmailAddress();

            Assert.Equal(expectedEmailAddress, result);
        }
        
        [Fact]
        public void GetId_WithValidUser_ReturnsCorrectId()
        {
            const int id = 1;
            const string userName = "testUserName";
            const string emailAddress = "testEmailAddress";
            const decimal monthlySalary = 1000;
            const decimal monthlyExpenses = 400;

            const int expectedId = 1;

            var user = new User.User(id, userName, emailAddress, monthlySalary, monthlyExpenses);

            var result = user.GetId();

            Assert.Equal(expectedId, result);
        }

    }
}
