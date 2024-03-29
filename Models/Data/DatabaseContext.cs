﻿using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using ProjectManagementApp.Models;

namespace ProjectManagementApp.Models.Data
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
            optionsBuilder.UseMySql("server=127.0.0.1;port=3306;database=PmaDb;uid=root;password=");
#endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("now()");
                entity.Property(e => e.LastEditedDate).HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired();
                entity.HasIndex(e => e.Username).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("now()");
                entity.Property(e => e.LastEditedDate).HasDefaultValueSql("now()");
                entity.HasOne(d => d.Account);
            });
        }
    }
}
