using System.ComponentModel.DataAnnotations;

namespace api_Bank.Dtos
{
    public class RegisterDto
    {
        [Required]
        public required string? Name { get; set; }
        [Required]
        public string Surname { get; set; } = null!;
        [Required]
        public string Patronymic { get; set; } = null!;
        [Required]
        [EmailAddress]
        public required string? Email { get; set; }
        [Required]
        public required string ? Password { get; set; }
        [Required]
        public required string? PhoneNumber { get; set; }
    }
}
