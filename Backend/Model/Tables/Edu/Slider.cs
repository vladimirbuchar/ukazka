using Model.Tables.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_Slider")]
    public class Slider : TableModel
    {
        [Column("Image")]
        public virtual string Image { get; set; }

        [Column("Priority")]
        public virtual int Priority { get; set; }
        public virtual BasicInformation BasicInformation { get; set; }
    }
}
