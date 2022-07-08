using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KontaktyAPI.Entities
{
    /// <summary>
    /// Creating database context
    /// </summary>
    public class ContactDB : DbContext
    {
        private string _connectionString =
            "Server=(localdb)\\mssqllocaldb;Database=ContactDB;Trusted_Connection=True;";
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// //Requirements of database's model for given Tables
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)      
        {

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<Role>()
                .Property(u => u.Name)
                .IsRequired();

            modelBuilder.Entity<Contact>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(15);

            modelBuilder.Entity<Contact>()
                .Property(r => r.Surname)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Category>()
                .Property(a => a.Role)
                .IsRequired()
                .HasMaxLength(15);




        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
