using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Database
{
    [Table("user_ext", Schema = "finance")]
    public partial class UserExt
    {
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
        [Column("CORP_ID")]
        public int? CorpId { get; set; }
        [Column("MAIN_DOCUMENT_NR")]
        [StringLength(22)]
        public string MainDocumentNr { get; set; }
        [Column("ISSUING_AUTHORITY")]
        [StringLength(44)]
        public string IssuingAuthority { get; set; }
        [Column("ISSUING_COUNTRY")]
        [StringLength(3)]
        public string IssuingCountry { get; set; }
        [Column("CARE_OF")]
        [StringLength(63)]
        public string CareOf { get; set; }
        [Column("ADDRESS_STREET")]
        [StringLength(126)]
        public string AddressStreet { get; set; }
        [Column("ADDRESS_POSTAL_CODE")]
        [StringLength(15)]
        public string AddressPostalCode { get; set; }
        [Column("ADDRESS_CITY_WITH_REGION")]
        [StringLength(126)]
        public string AddressCityWithRegion { get; set; }
        [Column("ADDRESS_COUNTRY_IN_FULL")]
        [StringLength(63)]
        public string AddressCountryInFull { get; set; }
        [Column("PHONE_WITH_IDD_CODE")]
        [StringLength(63)]
        public string PhoneWithIddCode { get; set; }
        [Column("MOBILE_WITH_IDD_CODE")]
        [StringLength(63)]
        public string MobileWithIddCode { get; set; }
    }
}
