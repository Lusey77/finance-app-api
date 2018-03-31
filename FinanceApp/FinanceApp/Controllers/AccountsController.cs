using System.Collections.Generic;
using System.Linq;
using FinanceApp.Model;
using FinanceApp.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<AccountModel> accounts = _accountService.GetAccounts();

            if (!accounts.Any()) return NotFound();

            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            AccountModel account = _accountService.GetAccount(id);

            if (account == null) return NotFound();

            return Ok(account);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateAccountModel model)
        {
            _accountService.CreateAccount(model);

            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] UpdateAccountModel model)
        {
            _accountService.UpdateAccount(model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _accountService.DeleteAccount(id);

            return Ok();
        }
    }
}