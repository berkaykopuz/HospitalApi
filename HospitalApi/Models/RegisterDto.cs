using System.ComponentModel.DataAnnotations;

namespace HospitalApi.Models
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Name is required.")]
        public String? Name { get; init; }

        [Required(ErrorMessage = "Email is required.")]
        public String? Email { get; init; }

        [Required(ErrorMessage = "Password is required.")]
        public String? Password { get; init; }
    }
}
