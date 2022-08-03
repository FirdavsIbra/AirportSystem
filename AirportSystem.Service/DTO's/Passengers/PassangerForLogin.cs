using System.ComponentModel.DataAnnotations;

namespace AirportSystem.Service.DTO_s.Passengers
{
    public class PassangerForLogin
    {
        [Required(AllowEmptyStrings = false)]
        public string Username { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
    }
}