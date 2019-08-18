using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using ProjectManagementApp.Models;

namespace ProjectManagementApp
{
    public class DatabaseContext :  DbContext
    {
        public DbSet<Account> Account { get; set; }

        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if RELEASE
            optionsBuilder.UseMySQL("server=127.0.0.1;port=3306;database=PmaDb;uid=root;password=dbpassword");
#else
            optionsBuilder.UseMySQL("server=127.0.0.1;port=3306;database=PmaDb;uid=root;password=");
#endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired();
                entity.HasOne(d => d.Account);
            });
        }
    }
}
