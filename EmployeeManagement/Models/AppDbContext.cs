using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models.Extensions;
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
            modelBuilder.Seed();
            modelBuilder.Entity<Employee>().Property(e => e.Departement).HasConversion<string>();
            modelBuilder.Entity<Employee>().Property(e => e.Gender).HasConversion<string>();
            modelBuilder.Entity<Employee>().Property(e => e.PhotoPath).IsRequired(false).HasDefaultValue("");
        }
    }
}