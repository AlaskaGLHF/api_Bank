namespace api_bank.Models;

public partial class BalanceHistory
{
    public int BalanceHistoryId { get; set; }

    public int CardId { get; set; }

    public decimal Newbalance { get; set; }

    public decimal Oldbalance { get; set; }

    public DateTime? Datetime { get; set; }

    public virtual Card Card { get; set; } = null!;
}
