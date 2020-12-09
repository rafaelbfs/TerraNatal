using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Database
{
    [Table("transaction", Schema = "finance")]
    public partial class Transaction
    {
        public Transaction()
        {
            AccountEntries = new HashSet<AccountEntries>();
        }

        [Key]
        [Column("TRANID")]
        public long Tranid { get; set; }
        [Column("HASH")]
        [StringLength(127)]
        public string Hash { get; set; }
        [Column("DESCRIPTION")]
        [StringLength(252)]
        public string Description { get; set; }
        [Column("FLAGS")]
        public int? Flags { get; set; }
        [Column("TRAN_TIMESTAMP")]
        public DateTime TranTimestamp { get; set; }

        [InverseProperty("Tran")]
        public virtual ICollection<AccountEntries> AccountEntries { get; set; }
    }
}
