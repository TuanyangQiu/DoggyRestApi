using System.ComponentModel.DataAnnotations;

namespace DoggyRestApi.DTOs
{
    public class LoginDTO
    {

        [Required(ErrorMessage = "User cannot be empty!")]
        [EmailAddress(ErrorMessage = "Invalid email address!")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password cannot be empty!")]
        public string Password { get; set; } = string.Empty;
    }
}
