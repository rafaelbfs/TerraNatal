using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Database
{
    [Table("account_entries", Schema = "finance")]
    public partial class AccountEntries
    {
        [Key]
        [Column("ACCOUNT_ID")]
        public int AccountId { get; set; }
        [Key]
        [Column("TRANID")]
        public long Tranid { get; set; }
        [Column("VALUE", TypeName = "numeric(15,3)")]
        public decimal? Value { get; set; }
        [Column("FLAGS")]
        public int? Flags { get; set; }
        [Column("SEQUENCE_NR")]
        public int? SequenceNr { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("AccountEntries")]
        public virtual Account Account { get; set; }
        [ForeignKey(nameof(Tranid))]
        [InverseProperty(nameof(Transaction.AccountEntries))]
        public virtual Transaction Tran { get; set; }
    }
}
