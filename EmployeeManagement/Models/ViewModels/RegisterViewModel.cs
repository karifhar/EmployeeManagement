using System.ComponentModel.DataAnnotations;
using EmployeeManagement.Ultilities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [ValidEmailDomain("test.com")]
        [Remote(action: "IsEmailUsed", controller: "Account")]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Input must contain at least 8 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } 
        
        [Required]
        [Display(Name = "Confirm Password")]
        [Compare(nameof(Password), ErrorMessage = "Password doest not match")]
        public string ConfirmPassword { get; set; }
    }
}