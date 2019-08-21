using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagementApp.Controllers
{

    [Route("api/[controller]")]
    public class PasswordEncrypterController : Controller
    {
        [HttpPost]
        public PwEncryptResult Post([FromBody]PwEncryptSubmit model)
        {
            string password = model.input;

            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = HashPassword(password, salt);
            var response = new PwEncryptResult
            {
                Input = password,
                Salt = Convert.ToBase64String(salt),
                Hash = hashed
            };
            return response;
        }


        [HttpPost("[action]")]
        public string GetHash([FromBody]PwEncryptSubmit model)
        {
            if(!string.IsNullOrEmpty(model.input) && !string.IsNullOrEmpty(model.salt))
            {
                byte[] salt = Convert.FromBase64String(model.salt);
                var hash = HashPassword(model.input, salt);
                return hash;
            }
            return "missingvalues";
        }




        public string HashPassword(string password, byte[] salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }

        public class PwEncryptSubmit
        {
            public string input { get; set; }
            public string salt { get; set; }
        }

        public class PwEncryptResult
        {
            public string Input { get; set; }
            public string Salt { get; set; }
            public string Hash { get; set; }
        }
    }
}