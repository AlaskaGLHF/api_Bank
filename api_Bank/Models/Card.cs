namespace api_bank.Models;

public class Card
{
    public int CardId { get; set; }

    public int UserId { get; set; }

    public string CardNumber { get; set; } = null!;

    public string? CardType { get; set; }

    public DateTime ExpirationDate { get; set; }

    public decimal? Balance { get; set; }

    public int CurrencyId { get; set; }

    public decimal? CreditLimit { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<BalanceHistory> BalanceHistories { get; set; } = new List<BalanceHistory>();

    public virtual Currency Currency { get; set; } = null!;

    public virtual ICollection<Transaction> TransactionFromCards { get; set; } = new List<Transaction>();

    public virtual ICollection<Transaction> TransactionToCards { get; set; } = new List<Transaction>();

    public virtual User User { get; set; } = null!;
}