using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ProjectManagementApp.Models;

namespace ProjectManagementApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InsertData();
            CreateWebHostBuilder(args).Build().Run();
        }

        private static void InsertData()
        {
            using (var context = new DatabaseContext())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();

                // Adds an account
                var account = new Account
                {
                    Id = Guid.NewGuid(),
                    Name = "TestAccount",
                    CreatedDate = DateTime.Now,
                    LastEditedDate = DateTime.Now
                };
                context.Account.Add(account);

                // Adds some users
                context.User.Add(new User
                {
                    Id = Guid.NewGuid(),
                    Username = "testuser1",
                    Password = "itisatest",
                    Email = "testuser1@testmail.com",
                    Account = account,
                    CreatedDate = DateTime.Now,
                    LastEditedDate = DateTime.Now
                });
                context.User.Add(new User
                {
                    Id = Guid.NewGuid(),
                    Username = "testuser2",
                    Password = "itisatest",
                    Email = "testuser2@testmail.com",
                    Account = account,
                    CreatedDate = DateTime.Now,
                    LastEditedDate = DateTime.Now
                });

                // Saves changes
                context.SaveChanges();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
