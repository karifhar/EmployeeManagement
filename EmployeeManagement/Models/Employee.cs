using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Contracts.Enums;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DepartementEnum Departement { get; set; }
        public GenderEnum Gender { get; set; }
        public string PhotoPath { get; set; }
    }
}