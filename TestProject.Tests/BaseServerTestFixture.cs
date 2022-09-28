using System;
using Microsoft.AspNetCore.Mvc.Testing;

namespace TestProject.Tests
{
    public class BaseServerTestFixture : IDisposable
    {
        public WebApplicationFactory<WebAPI.Program> Application;
        public BaseServerTestFixture()
        {
            Application = new WebApplicationFactory<WebAPI.Program>()
            .WithWebHostBuilder(builder =>
            {
                
            });
        }
        /// <summary>
        /// Gracefully shutdown the application, if not called the tests will hang.
        /// </summary>
        public void Dispose()
        {
            Application?.Dispose();
        }
    }
}
