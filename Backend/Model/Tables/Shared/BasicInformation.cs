using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Shared
{
    [Table("Shared_BasicInformation")]
    public class BasicInformation : TableModel
    {
        [Column("Name")]
        public virtual string Name { get; set; }
        [Column("Description")]
        public virtual string Description { get; set; }
    }
}
