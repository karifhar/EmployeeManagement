using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
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