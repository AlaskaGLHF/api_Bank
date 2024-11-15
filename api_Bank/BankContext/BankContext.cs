using api_bank.Models;
using Microsoft.EntityFrameworkCore;

namespace api_Bank.BankContext;

public partial class BankContext : DbContext
{
    public BankContext()
    {
    }

    public BankContext(DbContextOptions<BankContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<BalanceHistory> BalanceHistories { get; set; }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<CardRequest> CardRequests { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<TransactionStatus> TransactionStatuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("addresses_pkey");

            entity.ToTable("addresses");

            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.Flat).HasColumnName("flat");
            entity.Property(e => e.House)
                .HasMaxLength(10)
                .HasColumnName("house");
            entity.Property(e => e.Index).HasColumnName("index");
            entity.Property(e => e.Region)
                .HasMaxLength(50)
                .HasColumnName("region");
            entity.Property(e => e.Street)
                .HasMaxLength(50)
                .HasColumnName("street");

            entity.HasOne(d => d.Country).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("addresses_country_id_fkey");
        });

        modelBuilder.Entity<BalanceHistory>(entity =>
        {
            entity.HasKey(e => e.BalanceHistoryId).HasName("balance_history_pkey");

            entity.ToTable("balance_history");

            entity.Property(e => e.BalanceHistoryId).HasColumnName("balance_history_id");
            entity.Property(e => e.CardId).HasColumnName("card_id");
            entity.Property(e => e.Datetime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datetime");
            entity.Property(e => e.Newbalance)
                .HasPrecision(15, 2)
                .HasColumnName("newbalance");
            entity.Property(e => e.Oldbalance)
                .HasPrecision(15, 2)
                .HasColumnName("oldbalance");

            entity.HasOne(d => d.Card).WithMany(p => p.BalanceHistories)
                .HasForeignKey(d => d.CardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("balance_history_card_id_fkey");
        });

        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(e => e.CardId).HasName("cards_pkey");

            entity.ToTable("cards");

            entity.HasIndex(e => e.CardNumber, "cards_card_number_key").IsUnique();

            entity.Property(e => e.CardId).HasColumnName("card_id");
            entity.Property(e => e.Balance)
                .HasPrecision(15, 2)
                .HasDefaultValueSql("0.00")
                .HasColumnName("balance");
            entity.Property(e => e.CardNumber)
                .HasMaxLength(16)
                .HasColumnName("card_number");
            entity.Property(e => e.CardType)
                .HasMaxLength(10)
                .HasColumnName("card_type");
            entity.Property(e => e.CreditLimit)
                .HasPrecision(15, 2)
                .HasDefaultValueSql("0.00")
                .HasColumnName("credit_limit");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.ExpirationDate).HasColumnName("expiration_date");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("is_deleted");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Currency).WithMany(p => p.Cards)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cards_currency_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Cards)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cards_user_id_fkey");
        });

        modelBuilder.Entity<CardRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("card_requests_pkey");

            entity.ToTable("card_requests");

            entity.Property(e => e.RequestId).HasColumnName("request_id");
            entity.Property(e => e.CardType)
                .HasMaxLength(10)
                .HasColumnName("card_type");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("is_deleted");
            entity.Property(e => e.RequestDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("request_date");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.CardRequests)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("card_requests_user_id_fkey");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("countries_pkey");

            entity.ToTable("countries");

            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.CurrencyId).HasName("currency_pkey");

            entity.ToTable("currency");

            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Rate)
                .HasPrecision(10, 5)
                .HasColumnName("rate");
            entity.Property(e => e.Symbol)
                .HasMaxLength(1)
                .HasColumnName("symbol");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("employees_pkey");

            entity.ToTable("employees");

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .HasColumnName("department");
            entity.Property(e => e.HireDate).HasColumnName("hire_date");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("is_deleted");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .HasColumnName("patronymic");
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .HasColumnName("position");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("notifications_pkey");

            entity.ToTable("notifications");

            entity.Property(e => e.NotificationId).HasColumnName("notification_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("is_deleted");
            entity.Property(e => e.IsRead)
                .HasDefaultValue(false)
                .HasColumnName("is_read");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("notifications_user_id_fkey");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasKey(e => e.SettingId).HasName("settings_pkey");

            entity.ToTable("settings");

            entity.Property(e => e.SettingId).HasColumnName("setting_id");
            entity.Property(e => e.CurrencyDisplay)
                .HasMaxLength(3)
                .HasColumnName("currency_display");
            entity.Property(e => e.Language)
                .HasMaxLength(10)
                .HasColumnName("language");
            entity.Property(e => e.NotificationPreferences)
                .HasMaxLength(20)
                .HasColumnName("notification_preferences");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Settings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("settings_user_id_fkey");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("transactions_pkey");

            entity.ToTable("transactions");

            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.Amount)
                .HasPrecision(15, 2)
                .HasColumnName("amount");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.FromCardId).HasColumnName("from_card_id");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("is_deleted");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.ToCardId).HasColumnName("to_card_id");
            entity.Property(e => e.TransactionDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("transaction_date");

            entity.HasOne(d => d.Currency).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transactions_currency_id_fkey");

            entity.HasOne(d => d.FromCard).WithMany(p => p.TransactionFromCards)
                .HasForeignKey(d => d.FromCardId)
                .HasConstraintName("transactions_from_card_id_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("transactions_status_id_fkey");

            entity.HasOne(d => d.ToCard).WithMany(p => p.TransactionToCards)
                .HasForeignKey(d => d.ToCardId)
                .HasConstraintName("transactions_to_card_id_fkey");
        });

        modelBuilder.Entity<TransactionStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("transaction_status_pkey");

            entity.ToTable("transaction_status");

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(20)
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "users_phone_number_key").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.HashPassword)
                .HasMaxLength(255)
                .HasColumnName("hash_password");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(255)
                .HasColumnName("image_path");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("is_deleted");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .HasColumnName("patronymic");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .HasColumnName("phone_number");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");

            entity.HasOne(d => d.Country).WithMany(p => p.Users)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("users_country_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
