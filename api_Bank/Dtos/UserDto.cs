using Swashbuckle.AspNetCore.Annotations;

namespace api_Bank.Dtos
{
    public class UserDto
    {

        [SwaggerSchema("UserDto.Read Schema")]
        public class UserDtoRead
        {
            public int UserId { get; set; }
            public required string Name { get; set; }
            public required string Surname { get; set; }
            public required string Patronymic { get; set; }
            public required string Email { get; set; }
            public string? PhoneNumber { get; set; }
            public DateTime? CreatedDate { get; set; }
            public int? CountryId { get; set; }
            public string? Status { get; set; }
            public bool? IsDeleted { get; set; }
            public DateTime? DeletedAt { get; set; }
            public string? ImagePath { get; set; }
        }

        [SwaggerSchema("UserDto.Create Schema")]
        public class UserDtoCreate
        {
            public required string Name { get; set; }
            public required string Surname { get; set; }
            public required string Patronymic { get; set; }
            public required string Email { get; set; }
            public string? PhoneNumber { get; set; }
            public required string HashPassword { get; set; }
            public int? CountryId { get; set; }
            public string? Status { get; set; }
            public string? ImagePath { get; set; }
        }


        [SwaggerSchema("UserDto.Update Schema")]
        public class UserDtoUpdate
        {
            public int UserId { get; set; }
            public required string Name { get; set; }
            public required string Surname { get; set; }
            public required string Patronymic { get; set; }
            public required string Email { get; set; }
            public string? PhoneNumber { get; set; }
            public required string HashPassword { get; set; }
            public int? CountryId { get; set; }
            public string? Status { get; set; }
            public bool? IsDeleted { get; set; }
            public string? ImagePath { get; set; }
        }
    }
}
