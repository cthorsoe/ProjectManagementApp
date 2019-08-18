using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagementApp.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public List<Account> Get()
        {
            using (var context = new DatabaseContext())
            {
                var accounts = context.Account.AsEnumerable();
                return accounts.ToList();
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Account Get(string id)
        {
            using (var context = new DatabaseContext())
            {
                var account = context.Account.FirstOrDefault(x => x.Id.ToString() == id);
                return account;
            }
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
