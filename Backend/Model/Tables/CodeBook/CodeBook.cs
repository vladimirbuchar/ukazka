using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.CodeBook
{
    public abstract class CodeBook : TableModel
    {
        [Column("Name")]
        public virtual string Name { get; set; }
        [Column("Value")]
        public virtual string Value { get; set; }
        [Column("IsDefault")]
        public virtual bool IsDefault { get; set; } = false;
        [Column("Priority")]
        public virtual int Priority { get; set; } = 0;
    }
}
