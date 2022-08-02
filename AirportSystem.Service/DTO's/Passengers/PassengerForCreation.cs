using AirportSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSystem.Service.DTO_s.Passengers
{
    public class PassengerForCreation
    {

        [MaxLength(64), Required]
        public string FirstName { get; set; }

        [MaxLength(64), Required]
        public string LastName { get; set; }

        [MaxLength(16), Required]
        public string Phone { get; set; }

        [MaxLength(64), Required]
        public string Email { get; set; }

        [MaxLength(16), Required]
        public string PasportNumber { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public string CountryCode { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public AgeCategory AgeCategory { get; set; }
    }
}
