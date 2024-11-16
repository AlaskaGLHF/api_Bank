namespace api_Bank.Dtos
{
    public static class CardDto
    {
        public class Create
        {
            public int UserId { get; set; }
            public int CardId { get; set; }
            public string CardNumber { get; set; } = null!;
            public DateOnly ExpirationDate { get; set; }
            public decimal? Balance { get; set; }
            public bool? IsDeleted { get; set; }
            public DateTime? DeletedAt { get; set; }
        }

        public class Update
        {
            public string CardNumber { get; set; } = null!;
            public string? CardType { get; set; }
            public DateOnly ExpirationDate { get; set; }
            public decimal? Balance { get; set; }
            public decimal? CreditLimit { get; set; }
            public DateTime? DeletedAt { get; set; }
            public bool? IsDeleted { get; set; }
        }

        public class Read
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