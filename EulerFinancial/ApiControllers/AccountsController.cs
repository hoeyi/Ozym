using EulerFinancial.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EulerFinancial.Data.Model;
using EulerFinancial.Data.Context;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EulerFinancial.PageControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountsController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        // GET: api/<AccountsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var accounts = await accountService.SelectAllAsync();
            return Ok(accounts);
        }

        // GET api/<AccountsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if(accountService.ModelExists(id))
            {
                var account = await accountService.ReadAsync(id);
                return Ok(account);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<AccountsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AccountsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
