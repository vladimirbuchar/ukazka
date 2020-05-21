using Model.Tables.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_CourseItem")]
    public class CourseItem : TableModel
    {
        [Column("Html")]
        public virtual string Html { get; set; }
        public virtual BasicInformation BasicInformation { get; set; }
    }
}
