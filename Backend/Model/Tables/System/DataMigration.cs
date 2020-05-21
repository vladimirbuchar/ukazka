using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.System
{
    [Table("System_DataMigration")]
    public class DataMigration : TableModel
    {
        [Column("ExcelName")]
        public virtual string ExcelName { get; set; }
        [Column("ExcelLastModification")]
        public virtual DateTime ExcelLastModification { get; set; }
        [Column("FolderLastModification")]
        public virtual DateTime? FolderLastModification { get; set; }
        [Column("Status")]
        public virtual string Status { get; set; }
        [Column("ErrorMessage")]
        public virtual string ErrorMessage { get; set; }
    }
}
