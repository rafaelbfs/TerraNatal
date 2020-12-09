using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Database
{
    [Table("account_chart", Schema = "finance")]
    public partial class AccountChart
    {
        public AccountChart()
        {
            Account = new HashSet<Account>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("STANDARD")]
        [StringLength(23)]
        public string Standard { get; set; }
        [Column("COUNTRY_CODE")]
        [StringLength(4)]
        public string CountryCode { get; set; }
        [Column("DESCRIPTION")]
        [StringLength(127)]
        public string Description { get; set; }
        [Column("FLAGS")]
        public int? Flags { get; set; }
        [Column("OWNER")]
        public int? Owner { get; set; }

        [InverseProperty("ChartNavigation")]
        public virtual ICollection<Account> Account { get; set; }
    }
}
