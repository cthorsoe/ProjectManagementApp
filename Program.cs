using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
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

                if (!context.User.AsEnumerable().Any())
                {
                    // Adds an account
                    var account = new Account
                    {
                        Id = Guid.NewGuid(),
                        Name = "TestAccount"
                    };
                    context.Account.Add(account);

                    // Adds some users
                    var user1PwData = HashPassword("1234");
                    context.User.Add(new User
                    {
                        Id = Guid.NewGuid(),
                        Username = "testuser1",
                        Hash = user1PwData.Hash,
                        Salt = user1PwData.Salt,
                        Email = "testuser1@testmail.com",
                        Account = account
                    });

                    var user2PwData = HashPassword("1234");
                    context.User.Add(new User
                    {
                        Id = Guid.NewGuid(),
                        Username = "testuser2",
                        Hash = user2PwData.Hash,
                        Salt = user2PwData.Salt,
                        Email = "testuser2@testmail.com",
                        Account = account
                    });
                }
                // Saves changes
                context.SaveChanges();
            }
        }

        public static PasswordData HashPassword(string password)
        {
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            var response = new PasswordData
            {
                Salt = Convert.ToBase64String(salt),
                Hash = hashed
            };
            return response;
        }

        public class PasswordData
        {
            public string Hash { get; set; }
            public string Salt { get; set; }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
