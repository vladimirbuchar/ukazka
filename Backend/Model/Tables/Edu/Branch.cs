using Model.Tables.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_Branch")]
    public class Branch : TableModel
    {
        [Column("IsMainBranch")]
        public virtual bool IsMainBranch { get; set; }
        public virtual IEnumerable<ClassRoom> ClassRoom { get; set; }
        public virtual BasicInformation BasicInformation { get; set; }
        public virtual Address Address { get; set; }
        public virtual ContactInformation ContactInformation { get; set; }
    }
}