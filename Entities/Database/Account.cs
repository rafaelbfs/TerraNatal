using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Database
{
    [Table("account", Schema = "finance")]
    public partial class Account
    {
        public Account()
        {
            AccountEntries = new HashSet<AccountEntries>();
            InverseParentNavigation = new HashSet<Account>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("CHART")]
        public int? Chart { get; set; }
        [Required]
        [Column("CODE")]
        [StringLength(15)]
        public string Code { get; set; }
        [Column("NAME")]
        [StringLength(127)]
        public string Name { get; set; }
        [Column("DESCRIPTION")]
        [StringLength(255)]
        public string Description { get; set; }
        [Column("FLAGS")]
        public int? Flags { get; set; }
        [Required]
        [Column("CURRENCY")]
        [StringLength(4)]
        public string Currency { get; set; }
        [Column("PARENT")]
        public int? Parent { get; set; }

        [ForeignKey(nameof(Chart))]
        [InverseProperty(nameof(AccountChart.Account))]
        public virtual AccountChart ChartNavigation { get; set; }
        [ForeignKey(nameof(Parent))]
        [InverseProperty(nameof(Account.InverseParentNavigation))]
        public virtual Account ParentNavigation { get; set; }
        [InverseProperty("Account")]
        public virtual ICollection<AccountEntries> AccountEntries { get; set; }
        [InverseProperty(nameof(Account.ParentNavigation))]
        public virtual ICollection<Account> InverseParentNavigation { get; set; }
    }
}
