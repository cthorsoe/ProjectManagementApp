using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementApp.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; } 
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastEditedDate { get; set; }
        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
