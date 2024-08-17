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
            _context.Employees.Add(input);
            _context.SaveChanges();
            return input;
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
            return _context.Employees.Find(id) ?? throw new ArgumentException("Employee ID is not found");
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