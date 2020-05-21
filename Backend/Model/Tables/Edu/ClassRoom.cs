using Model.Tables.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_ClassRoom")]
    public class ClassRoom : TableModel
    {
        [Column("Floor")]
        public virtual int Floor { get; set; }
        [Column("MaxCapacity")]
        public virtual int MaxCapacity { get; set; }
        public virtual BasicInformation BasicInformation { get; set; }
       
    }
}