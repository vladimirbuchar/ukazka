using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_Inquiry")]
    public class Inquiry : TableModel
    {
        [Column("Subject")]
        public virtual string Subject { get; set; }
        [Column("ContactEmail")]
        public virtual string ContactEmail { get; set; }
        [Column("ContactPhone")]
        public virtual string ContactPhone { get; set; }
        [Column("ContactPhone")]
        public virtual string Text { get; set; }
        public virtual User User { get; set; }
    }
}
