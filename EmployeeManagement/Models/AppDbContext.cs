using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            modelBuilder.Entity<Employee>().Property(e => e.Departement).HasConversion<string>();
            modelBuilder.Entity<Employee>().Property(e => e.Gender).HasConversion<string>();
            modelBuilder.Entity<Employee>().Property(e => e.PhotoPath).IsRequired(false).HasDefaultValue("");
        }
    }
}