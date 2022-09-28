using TestProject.Tests.Extensions;
using TestProject.WebAPI.Models;
using Xunit;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;


namespace TestProject.Tests
{
    public class UserControllerTests : IClassFixture<BaseServerTestFixture>
    {
        private readonly BaseServerTestFixture _fixture;

        public UserControllerTests(BaseServerTestFixture fixture)
        {
            _fixture = fixture;
        }

        //User/Index
        //[Fact]
        [Fact(Skip = "This test will only work if there is data in the database")]
        public void Index_WithData_ReturnsUsers()
        {
            const string url = "/api/User/Index";

            using (var client = _fixture.Application.CreateClient())
            {

                var response = client.GetAsync(url).Result;

                var data = response.ReadBody<IEnumerable<UserModel>>();

                Assert.NotEmpty(data.Result);
            }
        }

        //User/Index
        //[Fact(Skip = "This test will only work if there is no data in the database")]
        [Fact]
        public void Index_WithNoData_ReturnsNotFoundResult()
        {
            const string url = "/api/User/Index";
            const string responseMessage = "No users found";

            using (var client = _fixture.Application.CreateClient())
            {
                var response = client.GetAsync(url).Result;

                var data = response.ReadBody();


                Assert.Equal(responseMessage, data.Result);

            }
        }

        //User/CreateUser
        [Fact]
        //[Fact(Skip = "This will may fail if you enter an email address of an existing user. This test only tests creating a new user successfully")]
        public void CreateUser_WithUniqueUser_CreatesNewUser()
        {
            const string url = "/api/User/CreateUser";
            const string responseMessage = "User successfully created";
            var request = JsonConvert.SerializeObject(new UserModel
            {
                Name = "test",
                EmailAddress = "test78@test.com",
                MonthlyExpenses = 500,
                MonthlySalary = 500
            });

            using (var client = _fixture.Application.CreateClient())
            {
                var response = client.PostAsync(url, new StringContent(request, Encoding.UTF8, "application/json"))
                    .Result;

                var data = response.ReadBody();

                Assert.Equal(responseMessage, data.Result);

            }
        }

        //User/CreateUser
        //[Fact]
        [Fact(Skip = "This test will only work if there is data in the database")]
        public void CreateUser_WithExistingUser_ThrowsError()
        {
            const string url = "/api/User/CreateUser";
            const string responseMessage = "User with email address already exists";
            var request = JsonConvert.SerializeObject(new UserModel
            {
                Name = "test",
                EmailAddress = "test58@test.com",
                MonthlyExpenses = 500,
                MonthlySalary = 500
            });

            using (var client = _fixture.Application.CreateClient())
            {
                var response = client.PostAsync(url, new StringContent(request, Encoding.UTF8, "application/json"))
                    .Result;

                var data = response.ReadBody();

                Assert.Equal(responseMessage, data.Result);

            }
        }

        //User/CreateUser
        [Fact]
        public void CreateUser_WithInvalidMonthlyExpenses_ThrowsError()
        {
            const string url = "/api/User/CreateUser";
            const string responseMessage = "Monthly Expenses must be a positive number.";
            var request = JsonConvert.SerializeObject(new UserModel
            {
                Name = "test",
                EmailAddress = "test58@test.com",
                MonthlyExpenses = -500,
                MonthlySalary = 500
            });

            using (var client = _fixture.Application.CreateClient())
            {
                var response = client.PostAsync(url, new StringContent(request, Encoding.UTF8, "application/json"))
                    .Result;

                var data = response.ReadBody();

                Assert.Equal(responseMessage, data.Result);

            }
        }

        //User/CreateUser
        [Fact]
        public void CreateUser_WithInvalidMonthlySalary_ThrowsError()
        {
            const string url = "/api/User/CreateUser";
            const string responseMessage = "Monthly Salary must be a positive number.";
            var request = JsonConvert.SerializeObject(new UserModel
            {
                Name = "test",
                EmailAddress = "test58@test.com",
                MonthlyExpenses = 500,
                MonthlySalary = -500
            });

            using (var client = _fixture.Application.CreateClient())
            {
                var response = client.PostAsync(url, new StringContent(request, Encoding.UTF8, "application/json"))
                    .Result;

                var data = response.ReadBody();

                Assert.Equal(responseMessage, data.Result);

            }
        }

        //User/Get
        //[Fact]
        [Fact(Skip = "This test will only work if there is data in the database")]
        public void Get_WithGivenId_ReturnsUser()
        {
            const string url = "/api/User/Get?id=1";

            using (var client = _fixture.Application.CreateClient())
            {
                var response = client.GetAsync(url).Result;

                var data = response.ReadBody<UserModel>();

                var name = data.Result.Name;

                Assert.NotNull(name);
            }
        }

        //User/Get
        [Fact]
        public void Get_WithGivenInvalidId_ReturnsEmptyResult()
        {
            const string url = "/api/User/Get?id=-1";
            const string responseMessage = "No data found for id -1";

            using (var client = _fixture.Application.CreateClient())
            {
                var response = client.GetAsync(url).Result;

                var data = response.ReadBody();

                Assert.Equal(responseMessage, data.Result);
            }
        }
    }
}