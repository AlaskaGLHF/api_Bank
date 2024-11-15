namespace api_bank.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int? FromCardId { get; set; }

    public int? ToCardId { get; set; }

    public decimal Amount { get; set; }

    public DateTime? TransactionDate { get; set; }

    public int CurrencyId { get; set; }

    public int? StatusId { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Currency Currency { get; set; } = null!;

    public virtual Card? FromCard { get; set; }

    public virtual TransactionStatus? Status { get; set; }

    public virtual Card? ToCard { get; set; }
}
