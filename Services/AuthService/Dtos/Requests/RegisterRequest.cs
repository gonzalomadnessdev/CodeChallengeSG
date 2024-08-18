using System.ComponentModel.DataAnnotations;

namespace AuthService.Dtos.Requests
{
    public class RegisterRequest
    {
        [Required]
        [StringLength(25, MinimumLength = 5)]
        public string Username { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 5)]
        public string Password { get; set; }
    }
}
