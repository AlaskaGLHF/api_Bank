using System.ComponentModel.DataAnnotations;

namespace api_Bank.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Telephone { get; set; }
    }
}
