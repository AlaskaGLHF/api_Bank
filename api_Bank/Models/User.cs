using System;
using System.Collections.Generic;

namespace api_bank.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string HashPassword { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public int? CountryId { get; set; }

    public string? Status { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? ImagePath { get; set; }

    public virtual ICollection<CardRequest> CardRequests { get; set; } = new List<CardRequest>();

    public virtual ICollection<Card> Cards { get; set; } = new List<Card>();

    public virtual Country? Country { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Setting> Settings { get; set; } = new List<Setting>();
}
