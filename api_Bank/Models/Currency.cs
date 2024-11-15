namespace api_bank.Models;

public partial class Currency
{
    public int CurrencyId { get; set; }

    public string Symbol { get; set; } = null!;

    public string Name { get; set; } = null!;

    public decimal Rate { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Card> Cards { get; set; } = new List<Card>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
