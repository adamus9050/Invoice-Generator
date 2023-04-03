using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Identification
{
    public class Login
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
