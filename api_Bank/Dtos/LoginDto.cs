using System.ComponentModel.DataAnnotations;

namespace api_Bank.Dtos
{
    public class LoginDto
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Password { get; set; }
    }
    public class NewUserDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public required string Token { get; set; }
    }
}
