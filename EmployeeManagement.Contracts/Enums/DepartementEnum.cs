using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Contracts.Enums
{
    public enum DepartementEnum
    {
        IT,
        Finance,
        [Display( Name = "Human Resource")]
        Human_Resource
    }
}