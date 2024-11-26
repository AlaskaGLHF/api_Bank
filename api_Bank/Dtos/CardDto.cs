using Swashbuckle.AspNetCore.Annotations;

namespace api_Bank.Dtos
{
    public static class CardDto
    {

        [SwaggerSchema("CardDto.Create Schema")]
        public class CardDtoCreate
        {
            public int UserId { get; set; }
            public int CardId { get; set; }
            public string CardNumber { get; set; } = null!;
            public DateOnly ExpirationDate { get; set; }
            public decimal? Balance { get; set; }
            public bool? IsDeleted { get; set; }
            public DateTime? DeletedAt { get; set; }
        }

        [SwaggerSchema("CardDto.Update Schema")]
        public class CardDtoUpdate
        {
            public required string CardNumber { get; set; }
            public string? CardType { get; set; }
            public DateOnly ExpirationDate { get; set; }
            public decimal? Balance { get; set; }
            public decimal? CreditLimit { get; set; }
            public DateTime? DeletedAt { get; set; }
            public bool? IsDeleted { get; set; }
        }

        [SwaggerSchema("CardDto.Read Schema")]
        public class CardDtoRead
        {
            public int CardId { get; set; }
            public int UserId { get; set; }
            public string CardNumber { get; set; } = null!;
            public string? CardType { get; set; }
            public DateOnly ExpirationDate { get; set; }
            public decimal? Balance { get; set; }
            public int CurrencyId { get; set; }
            public decimal? CreditLimit { get; set; }
            public bool? IsDeleted { get; set; }
            public DateTime? DeletedAt { get; set; }
        }
    }
}