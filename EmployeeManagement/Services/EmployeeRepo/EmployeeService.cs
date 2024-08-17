using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Contracts.Enums;
using EmployeeManagement.Contracts.Request;
using EmployeeManagement.Models;

namespace EmployeeManagement.Services.EmployeeRepo
{
    public class EmployeeService : IEmployeeService
    {
        private List<Employee> MockEmployee = new List<Employee> 
        {
            new Employee {Id= 1, Name = "Rifqa", Email= "me123@gmail.com", Departement=DepartementEnum.IT, Gender = GenderEnum.Male},
            new Employee {Id= 2, Name = "Batsu", Email= "test1@gmail.com", Departement=DepartementEnum.IT, Gender = GenderEnum.Male},
            new Employee {Id= 3, Name = "dimas", Email= "dim@gmail.com", Departement=DepartementEnum.IT, Gender = GenderEnum.Male},
            new Employee {Id= 4, Name = "elma", Email= "elma@gmail.com", Departement=DepartementEnum.Finance, Gender = GenderEnum.Female},
            new Employee {Id= 5, Name = "Agustin", Email= "erni@gmail.com", Departement=DepartementEnum.Human_Resource, Gender = GenderEnum.Female}
        };

        public Employee CreateEmployee(Employee input)
        {
            Employee newEmployee = new Employee() {
                Id = MockEmployee.Max(x => x.Id) + 1,
                Name = input.Name,
                Email = input.Email,
                Departement = input.Departement,
                Gender = input.Gender,
            };

            MockEmployee.Add(newEmployee);

            return newEmployee;
        }

        public void Delete(int id)
        {
            Employee employee = MockEmployee.FirstOrDefault(e => e.Id == id);

            if (employee == null)
             throw new ArgumentException("Employee ID not Found");
            
            MockEmployee.Remove(employee);  
        }

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

        public Employee Update(Employee input)
        {
            Employee employee = MockEmployee.FirstOrDefault(e => e.Id == input.Id);

            if (employee == null)
             throw new ArgumentException("Employee ID not Found");
            
            int index = MockEmployee.IndexOf(employee);

            MockEmployee[index].Name = input.Name;
            MockEmployee[index].Email = input.Email;
            MockEmployee[index].Gender = input.Gender;
            MockEmployee[index].Departement = input.Departement;

            return MockEmployee[index];

        }
    }
}