using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;

namespace EmployeeManagement.Services.EmployeeRepo
{
    public class SQLEmployeeRepo : IEmployeeService
    {
        private readonly AppDbContext _context;

        public SQLEmployeeRepo(AppDbContext context)
        {
            _context = context;
        }

        public Employee CreateEmployee(Employee input)
        {
            Employee newEmployee = new Employee() {
                Name = input.Name,
                Email = input.Email,
                Gender = input.Gender,
                Departement = input.Departement,
                PhotoPath = string.IsNullOrWhiteSpace(input.PhotoPath) ? "" : input.PhotoPath,
            };

            _context.Employees.Add(newEmployee);
            _context.SaveChanges();
            return newEmployee;
        }

        public void Delete(int id)
        {
            Employee employee = _context.Employees.Find(id);

            if (employee == null)
                throw new ArgumentException("Employee ID is not found");
            
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee = _context.Employees.Find(id);

            return employee ?? throw new Exception("Employee ID is not found");
        }

        public List<Employee> GetEmployeeList()
        {
            return _context.Employees.ToList();
        }

        public Employee Update(Employee input)
        {
            Employee employee = _context.Employees.Find(input.Id);

            if (employee == null)
                throw new ArgumentException("Employee ID is not found");

            _context.Employees.Update(input);
            _context.SaveChanges();

            return input;
        }
    }
}