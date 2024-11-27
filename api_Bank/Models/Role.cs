using System;
using System.Collections.Generic;

namespace api_bank.Models;

public partial class Role
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

    public int? RoleId { get; set; }
}
