using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Contracts.Enums;

namespace EmployeeManagement.Contracts.Request
{
    public class EmployeeInput
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Departement { get; set; }
        public GenderEnum Gender { get; set; }
    }
}