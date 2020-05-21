using Model.Tables.CodeBook;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Shared
{
    [Table("Shared_Address")]
    public class Address : TableModel
    {
        public virtual Country Country { get; set; }
        [Column("Region")]
        public virtual string Region { get; set; }
        [Column("City")]
        public virtual string City { get; set; }
        [Column("Street")]
        public virtual string Street { get; set; }
        [Column("HouseNumber")]
        public virtual string HouseNumber { get; set; }
        [Column("ZipCode")]
        public virtual string ZipCode { get; set; }
        public virtual AddressType AddressType { get; set; }
    }
}
