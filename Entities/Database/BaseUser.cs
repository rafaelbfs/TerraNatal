using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Database
{
    [Table("base_user", Schema = "finance")]
    public partial class BaseUser
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("FEDERATED_IDENTIFIER")]
        [StringLength(63)]
        public string FederatedIdentifier { get; set; }
        [Required]
        [Column("EMAIL")]
        [StringLength(63)]
        public string Email { get; set; }
        [Required]
        [Column("NAME_OR_TRADEMARK")]
        [StringLength(127)]
        public string NameOrTrademark { get; set; }
        [Column("COUNTRY")]
        [StringLength(3)]
        public string Country { get; set; }
        [Column("USER_CLASS")]
        [StringLength(4)]
        public string UserClass { get; set; }
        [Column("TYPE")]
        public short? Type { get; set; }
    }
}
