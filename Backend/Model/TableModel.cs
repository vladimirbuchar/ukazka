using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public abstract class TableModel
    {
        [Key]
        [Column("Id")]
        public virtual Guid Id { get; set; }

        [Column("IsDeleted")]
        public virtual bool IsDeleted { get; set; } = false;

        [Column("IsSystemObject")]
        public virtual bool IsSystemObject { get; set; } = false;

        [Column("IsChanged")]
        public virtual bool IsChanged { get; set; } = true;

        [Column("SystemIdentificator")]
        public virtual string SystemIdentificator { get; set; }
    }
}