using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using TestProject.WebAPI.Models;
using TestProject.Service.Interface.User;
using TestProject.Data.Interface.User;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TestProject.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICreateUserService _createUser;
        private readonly IUserRepository _userRepository;
        public UserController(ICreateUserService createUser, IUserRepository userRepository)
        {
            _createUser = createUser;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var data = await _userRepository.Get();
                if (data == null || data.Count() == 0)
                    return Ok("No users found");

                var model = new List<Models.UserModel>();

                foreach(var item in data)
                {
                    model.Add(new UserModel
                    {
                        Id = item.GetId(),
                        EmailAddress = item.GetEmailAddress(),
                        MonthlyExpenses = item.GetMonthlyExpenses(),
                        MonthlySalary = item.GetMonthlySalary(),
                        Name = item.GetUsername()
                    });
                }

                return Ok(model);
            }
            catch(Exception e)
            {
                return new ContentResult
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Content = e.Message
                };
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserModel model)
        {
            try
            {
                await _createUser.CreateNewUser(new Core.User.User(model.Name, model.EmailAddress, model.MonthlySalary, model.MonthlyExpenses));

                return Ok("User successfully created");
            }
            catch(Exception e)
            {
                return new ContentResult
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Content = e.Message
                };
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var data = await _userRepository.GetById(id);

                if (data == null)
                    return Ok($"No data found for id {id}");

                var model = new Models.UserModel
                {
                    Id = data.GetId(),
                    EmailAddress = data.GetEmailAddress(),
                    MonthlyExpenses = data.GetMonthlyExpenses(),
                    MonthlySalary = data.GetMonthlySalary(),
                    Name = data.GetUsername()
                };

                
                return Ok(model);
            }
            catch (Exception e)
            {
                return new ContentResult
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Content = e.Message
                };
            }
        }
    }
}
