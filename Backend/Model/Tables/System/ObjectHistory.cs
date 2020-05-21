using Model.Tables.Edu;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.System
{
    public struct EventTypeValue
    {
        public const string ADD = "ADD";
        public const string UPDATE = "UPDATE";
        public const string DELETE = "DELETE";
    }
    [Table("System_ObjectHistory")]
    public class ObjectHistory : TableModel
    {
        [Column("ObjectId")]
        public virtual Guid ObjectId { get; set; }
        [Column("OldValue")]
        public virtual string OldValue { get; set; }
        [Column("NewValue")]
        public virtual string NewValue { get; set; }
        [Column("ObjectType")]
        public virtual string ObjectType { get; set; }
        [Column("EventType")]
        public virtual string EventType { get; set; }
        [Column("ActionTime")]
        public virtual DateTime ActionTime { get; set; }
        public virtual User User { get; set; }
    }
}
