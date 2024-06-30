using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Contracts.Enums;
using EmployeeManagement.Models;

namespace EmployeeManagement.Services.EmployeeRepo
{
    public class EmployeeService : IEmployeeService
    {
        private List<Employee> MockEmployee = new List<Employee> 
        {
            new Employee {Id= 1, Name = "Rifqa", Email= "me123@gmail.com", Departement="IT", Gender = GenderEnum.Male},
            new Employee {Id= 2, Name = "Batsu", Email= "test1@gmail.com", Departement="IT", Gender = GenderEnum.Male},
            new Employee {Id= 3, Name = "dimas", Email= "dim@gmail.com", Departement="IT", Gender = GenderEnum.Male},
            new Employee {Id= 4, Name = "elma", Email= "elma@gmail.com", Departement="HR", Gender = GenderEnum.Female},
            new Employee {Id= 5, Name = "Agustin", Email= "erni@gmail.com", Departement="HR", Gender = GenderEnum.Female}
        };
        public Employee GetEmployeeById(int id)
        {
            Employee employee = MockEmployee.FirstOrDefault(x => x.Id == id);

            if(employee == null)
                throw new Exception();

            return employee;
        }
        public List<Employee> GetEmployeeList()
        {
            return MockEmployee;
        }
    }
}