using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementApp.Models.Data;
using ProjectManagementApp.Models.ViewModels;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagementApp.Controllers
{

    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [HttpGet]
        public List<UserViewModel> Get()
        {
            using (var context = new DatabaseContext())
            {
                var users = context.User.AsEnumerable().Select(x => new UserViewModel
                {
                    Id = x.Id,
                    Username = x.Username,
                    Email = x.Email,
                    Created = x.CreatedDate
                });
                return users.ToList();
            }
        }

        [HttpGet("{id}")]
        public UserViewModel Get(string id)
        {
            using (var context = new DatabaseContext())
            {
                var dbUser = context.User.FirstOrDefault(x => x.Id.ToString() == id);
                UserViewModel user = new UserViewModel
                {
                    Id = dbUser.Id,
                    Username = dbUser.Username,
                    Email = dbUser.Email,
                    Created = dbUser.CreatedDate
                };
                return user;
            }
        }

        [HttpGet("[action]")]
        public List<UserViewModel> Account(string id)
        {
            using (var context = new DatabaseContext())
            {
                var users = context.User.Where(x => x.Account.Id.ToString() == id).Select(x => new UserViewModel
                {
                    Id = x.Id,
                    Username = x.Username,
                    Email = x.Email,
                    Created = x.CreatedDate
                });
                return users.ToList();
            }
        }
    }
}
