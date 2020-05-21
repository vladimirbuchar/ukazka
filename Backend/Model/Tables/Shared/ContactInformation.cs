using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Shared
{
    [Table("Shared_ContactInformation")]
    public class ContactInformation : TableModel
    {
        [Column("Email")]
        public virtual string Email { get; set; }
        [Column("PhoneNumber")]
        public virtual string PhoneNumber { get; set; }
        [Column("WWW")]
        public virtual string WWW { get; set; }
    }
}
