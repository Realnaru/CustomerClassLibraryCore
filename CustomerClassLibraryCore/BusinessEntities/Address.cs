using CustomerClassLibraryCore.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CustomerClassLibraryCore.BusinessEntities
{
    public enum AddressType
    {
        Shipping,
        Billing
    }

    [Serializable, Table("dbo.customer_address")]
    public class Address
    {
        [Key, Column("address_id")]
        public int AddressId { get; set; }
        [Column("customer_id")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "The field is required"),
            MaxLength(100, ErrorMessage = "Maximum length is 100 characters"), Column("address_line")]

        public string AdressLine { get; set; }

        [MaxLength(100, ErrorMessage = "Maximum length is 100 characters"), Column("address_line2")]
        public string AdressLine2 { get; set; }
        [NotMapped]
        public AddressType AddressTypeEnum { get; set; }

        [Column("address_type")]
        public string AddressType
        {
            get
            {
                return AddressTypeEnum.ToString();
            }
            set
            {
                AddressTypeEnum = (AddressType)Enum.Parse(typeof(AddressType), value, true);
            }
        }

        [Required(ErrorMessage = "The field is required"), MaxLength(50, ErrorMessage = "Maximum length is 50 characters"),
                                Column("city")]
        public string City { get; set; }

        [Required(ErrorMessage = "The field is required"),
            MaxLength(6, ErrorMessage = "Maximum length is 6 characters"), Column("postal_code")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "The field is required"),
            MaxLength(20, ErrorMessage = "Maximum length is 20 characters"), Column("state")]
        public string State { get; set; }

        [Required(ErrorMessage = "The field is required"),
            USAorCanada(ErrorMessage = "The field can be only USA or Canada"), Column("country")]
        public string Country { get; set; }
    }
}
