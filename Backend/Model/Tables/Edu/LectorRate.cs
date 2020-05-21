using Model.Tables.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_LectorRate")]
    public class LectorRate : TableModel
    {
        public virtual User Lector { get; set; }
        public virtual User Student { get; set; }
        public virtual int Rate { get; set; }
        public virtual BasicInformation BasicInformation { get; set; }
    }
}
