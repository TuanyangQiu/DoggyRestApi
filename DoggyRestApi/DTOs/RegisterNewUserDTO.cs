using System.ComponentModel.DataAnnotations;

namespace DoggyRestApi.DTOs
{
    public class RegisterNewUserDTO
    {
        [Required(ErrorMessage = "User cannot be empty!")]
        [EmailAddress(ErrorMessage = "Invalid email address!")]
        public string Email { get; set; } = string.Empty;


        [Required(ErrorMessage = "Password cannot be empty!")]
        public string Password { get; set; } = string.Empty;


        [Required(ErrorMessage = "Confirm password cannot be empty!")]
        [Compare(nameof(Password), ErrorMessage = "Confirm password should be same as password!")]
        public string ConfirmPassword { get; set; } = string.Empty;

    }
}
