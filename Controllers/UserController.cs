using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagementApp.Controllers
{

    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [HttpGet]
        public List<User> Get()
        {
            using (var context = new DatabaseContext())
            {
                var users = context.User.AsEnumerable();
                return users.ToList();
            }
        }

        [HttpGet("{id}")]
        public User Get(string id)
        {
            using (var context = new DatabaseContext())
            {
                var user = context.User.FirstOrDefault(x => x.Id.ToString() == id);
                return user;
            }
        }

        [HttpGet("[action]")]
        public List<User> Account(string id)
        {
            using (var context = new DatabaseContext())
            {
                var users = context.User.Where(x => x.Account.Id.ToString() == id);
                return users.ToList();
            }
        }
    }
}
