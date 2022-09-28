using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TestProject.Tests.Extensions;
using TestProject.WebAPI.Models;
using Xunit;

namespace TestProject.Tests
{
    public class AccountControllerTests : IClassFixture<BaseServerTestFixture>
    {
        private readonly BaseServerTestFixture _fixture;

        public AccountControllerTests(BaseServerTestFixture baseTestFixture)
        {
            _fixture = baseTestFixture;
        }

        //Account/Index
        //[Fact]
        [Fact(Skip = "This test only works if there is data in the database.")]
        public void Index_WithData_ReturnsData()
        {
            const string url = "/api/Account/Index";

            using (var client = _fixture.Application.CreateClient())
            {

                var response = client.GetAsync(url).Result;

                var data = response.ReadBody<IEnumerable<AccountModel>>();

                var model = data.Result;

                Assert.NotNull(model);
            }
        }


        //Account/Index
        //[Fact(Skip = "This test only works if there is no data in the database.")]
        [Fact]
        public void Index_WithNoData_ReturnsEmptyString()
        {
            const string url = "/api/Account/Index";
            const string result = "No accounts found";
            using (var client = _fixture.Application.CreateClient())
            {
                var response = client.GetAsync(url).Result;


                var data = response.ReadBody();

                Assert.Equal(result, data.Result);
            }
        }

        //Account/CreateAccount
        [Fact]
        public void CreateAccount_WithUserIdNotFound_ReturnsMessage()
        {
            const string responseMessage = "user not found, when trying to create account";
            const string url = "/api/Account/CreateAccount";

            using (var client = _fixture.Application.CreateClient())
            {
                var request = JsonConvert.SerializeObject(new AccountModel { UserId = 100000 });

                var response = client.PostAsync(url, new StringContent(request, Encoding.UTF8, "application/json"))
                    .Result;


                var data = response.ReadBody();

                Assert.Equal(responseMessage, data.Result);
            }
        }


        //Account/CreateAccount
        [Fact]
        public void CreateAccount_WithUserId_CreatesAccount()
        {
            const string responseMessage = "Account successfully created";
            const string url = "/api/Account/CreateAccount";

            using (var client = _fixture.Application.CreateClient())
            {
                var request = JsonConvert.SerializeObject(new AccountModel { UserId = 1002 });

                var response = client.PostAsync(url, new StringContent(request, Encoding.UTF8, "application/json"))
                    .Result;


                var data = response.ReadBody();

                Assert.Equal(responseMessage, data.Result);
            }
        }

        //Account/CreateAccount
        [Fact]
        public void CreateAccount_WithInvalidUserId_ReturnsMessage()
        {
            const string responseMessage = "Value cannot be null. (Parameter 'userId')";
            const string url = "/api/Account/CreateAccount";

            using (var client = _fixture.Application.CreateClient())
            {

                var request = JsonConvert.SerializeObject(new AccountModel { UserId = -10 });


                var response = client.PostAsync(url, new StringContent(request, Encoding.UTF8, "application/json"))
                    .Result;

                var data = response.ReadBody();

                Assert.Equal(responseMessage, data.Result);

            }
        }
    }
}
