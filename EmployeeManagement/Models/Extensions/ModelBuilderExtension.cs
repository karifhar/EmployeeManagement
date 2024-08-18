using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Contracts.Enums;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Models.Extensions
{
    public static class ModelBuilderExtension
    {   
        public static void Seed(this ModelBuilder modelBuilder) {
            modelBuilder.Entity<Employee>().HasData(
                new Employee {Id= 1, Name = "Rifqa", Email= "me@gmail.com", Departement=DepartementEnum.IT, Gender = GenderEnum.Male},
                new Employee {Id= 2, Name = "Batsu", Email= "bats@gmail.com", Departement=DepartementEnum.IT, Gender = GenderEnum.Male},
                new Employee {Id= 3, Name = "dimas", Email= "dim@gmail.com", Departement=DepartementEnum.IT, Gender = GenderEnum.Male},
                new Employee {Id= 4, Name = "elma", Email= "elma@gmail.com", Departement=DepartementEnum.Finance, Gender = GenderEnum.Female},
                new Employee {Id= 5, Name = "Agustin", Email= "erni@gmail.com", Departement=DepartementEnum.Human_Resource, Gender = GenderEnum.Female}
            );
        }
    }
}