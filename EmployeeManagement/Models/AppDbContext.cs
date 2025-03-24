using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models.Extensions;
using EmployeeManagement.Ultilities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().ApplyBaseEntityConfiguration();

            modelBuilder.Entity<Employee>().Property(e => e.Name).HasColumnType("Varchar(250)");
            modelBuilder.Entity<Employee>().Property(e => e.Email).HasColumnType("Varchar(500)");
            modelBuilder.Entity<Employee>().Property(e => e.Departement).HasConversion<string>().HasColumnType("Varchar(500)");
            modelBuilder.Entity<Employee>().Property(e => e.Gender).HasConversion<string>().HasColumnType("Varchar(500)");
            modelBuilder.Entity<Employee>().Property(e => e.PhotoPath).IsRequired(false).HasColumnType("Varchar(500)").HasDefaultValue("");
            modelBuilder.Entity<Employee>().Property(e => e.IsDeleted).HasConversion<bool>();
            modelBuilder.Seed();
        }

        public override int SaveChanges()
        {
            SetDefaultDate();
            return base.SaveChanges();
        }

        private void SetDefaultDate() {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>()) 
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedTime = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedTime = DateTime.UtcNow;
                        break;
                }
            }
        }
    }
}