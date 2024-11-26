namespace api_bank.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Department { get; set; } = null!;

    public string Position { get; set; } = null!;

    public DateOnly HireDate { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }
}
