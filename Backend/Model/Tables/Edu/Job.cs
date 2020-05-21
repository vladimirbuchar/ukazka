using Model.Tables.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_Job")]
    public class Job : TableModel
    {
        [Column("Salary")]
        public virtual int Salary { get; set; }
        public virtual BasicInformation BasicInformation { get; set; }
    }
}
