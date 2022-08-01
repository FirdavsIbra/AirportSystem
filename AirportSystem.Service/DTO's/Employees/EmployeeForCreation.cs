using AirportSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSystem.Service.DTO_s.Employees
{
    public class EmployeeForCreation
    {
        [Required(AllowEmptyStrings = false),MaxLength(64)]
        public string FirstName { get; set; }
        
        [Required(AllowEmptyStrings = false), MaxLength(64)]
        public string LastName { get; set; }
        
        [Required(AllowEmptyStrings = false), EmailAddress]
        public string Email { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public DateTime DateOfBirth { get; set; }
        
        [Required]
        public string Address { get; set; }
        
        [Required, MaxLength(32)]
        public string PassportNumber { get; set; }
        
        [Required, MaxLength(16),Phone]
        public string Phone { get; set; }
        
        [Required]
        public Gender Gender { get; set; }

        [Required]
        public Department Department { get; set; }
        
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public decimal Salary { get; set; }
    }
}
