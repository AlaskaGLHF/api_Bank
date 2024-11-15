namespace api_bank.Models;

public partial class CardRequest
{
    public int RequestId { get; set; }

    public int UserId { get; set; }

    public string? CardType { get; set; }

    public string? Status { get; set; }

    public DateTime? RequestDate { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
