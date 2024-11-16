using System;
using System.Collections.Generic;

namespace api_bank.Models;
public partial class Address
{
    public int AddressId { get; set; }

    public int? CountryId { get; set; }

    public string Region { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string House { get; set; } = null!;

    public int? Flat { get; set; }

    public int Index { get; set; }

    public virtual Country? Country { get; set; }
}
