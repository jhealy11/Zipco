using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Data.Interface.Account;
using TestProject.Service.Interface.Account;
using TestProject.WebAPI.Models;

namespace TestProject.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly ICreateAccountService _createAccount;
        private readonly IAccountRepository _accountRepository;

        public AccountController(ICreateAccountService createAccount, IAccountRepository accountRepository)
        {
            _createAccount = createAccount;
            _accountRepository = accountRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var data = await _accountRepository.Get();

                if (data == null || data.Count() == 0)
                    return Ok("No accounts found");

                var model = new List<AccountModel>();

                foreach (var account in data)
                {
                    model.Add(new AccountModel
                    {
                        Id = account.GetId(),
                        UserId = account.GetUser().GetId(),
                        User = new UserModel
                        {
                            Id = account.GetUser().GetId(),
                            EmailAddress = account.GetUser().GetEmailAddress(),
                            Name = account.GetUser().GetUsername(),
                            MonthlyExpenses = account.GetUser().GetMonthlyExpenses(),
                            MonthlySalary = account.GetUser().GetMonthlySalary()
                        }
                    });
                }

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


        [HttpPost]
        public async Task<IActionResult> CreateAccount(AccountModel model)
        {
            try
            {
                var account = new Core.Account.Account(model.UserId);
                await _createAccount.CreateAccount(account);
                
                return Ok("Account successfully created");
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
