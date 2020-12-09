using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Database
{
    public partial class FinanceContext : DbContext
    {
        public FinanceContext()
        {
        }

        public FinanceContext(DbContextOptions<FinanceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountChart> AccountChart { get; set; }
        public virtual DbSet<AccountEntries> AccountEntries { get; set; }
        public virtual DbSet<AdminUser> AdminUser { get; set; }
        public virtual DbSet<BaseUser> BaseUser { get; set; }
        public virtual DbSet<Corporation> Corporation { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<UserExt> UserExt { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasIndex(e => new { e.Chart, e.Code })
                    .HasName("IDX_ACCOUNT_SEARCH");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"account_ID_seq\"'::regclass)");

                entity.Property(e => e.Currency)
                    .IsFixedLength()
                    .HasComment("Three letter code of this account's currency. Example: USD, EUR.");

                entity.HasOne(d => d.ChartNavigation)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.Chart)
                    .HasConstraintName("FK_ACCTS_CHART");

                entity.HasOne(d => d.ParentNavigation)
                    .WithMany(p => p.InverseParentNavigation)
                    .HasForeignKey(d => d.Parent)
                    .HasConstraintName("FK_PARENT_ACCOUNT");
            });

            modelBuilder.Entity<AccountChart>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.CountryCode).IsFixedLength();
            });

            modelBuilder.Entity<AccountEntries>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.Tranid })
                    .HasName("PK_ACCOUNT_ENTRIES");

                entity.Property(e => e.SequenceNr).HasComment("This is the sequence number of this entry within the account");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountEntries)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ENTRY_ACCOUNT");

                entity.HasOne(d => d.Tran)
                    .WithMany(p => p.AccountEntries)
                    .HasForeignKey(d => d.Tranid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ENTRY_TRANSACTION");
            });

            modelBuilder.Entity<AdminUser>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AdminClearance).IsFixedLength();

                entity.Property(e => e.Country).IsFixedLength();

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"base_user_ID_seq\"'::regclass)");

                entity.Property(e => e.IssuingCountry).IsFixedLength();

                entity.Property(e => e.UserClass).IsFixedLength();
            });

            modelBuilder.Entity<BaseUser>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"base_user_ID_seq\"'::regclass)");

                entity.Property(e => e.Country).IsFixedLength();

                entity.Property(e => e.UserClass).IsFixedLength();
            });

            modelBuilder.Entity<Corporation>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Country).IsFixedLength();

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"base_user_ID_seq\"'::regclass)");

                entity.Property(e => e.IssuingCountry).IsFixedLength();

                entity.Property(e => e.UserClass).IsFixedLength();
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.Tranid)
                    .HasName("PK_TRANSACTION");

                entity.HasIndex(e => e.Hash)
                    .HasName("UK_TRANSACTION_HASH")
                    .IsUnique();

                entity.HasIndex(e => e.TranTimestamp)
                    .HasName("IDX_TRANSACTION_TIMESTAMP");

                entity.Property(e => e.Tranid).HasDefaultValueSql("nextval('\"transaction_TRANID_seq\"'::regclass)");

                entity.Property(e => e.TranTimestamp).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<UserExt>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Country).IsFixedLength();

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"base_user_ID_seq\"'::regclass)");

                entity.Property(e => e.IssuingCountry).IsFixedLength();

                entity.Property(e => e.UserClass).IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
