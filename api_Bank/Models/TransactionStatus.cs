using System;
using System.Collections.Generic;

namespace api_bank.Models;

public partial class TransactionStatus
{
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
