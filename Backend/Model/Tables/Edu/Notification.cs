using Model.Tables.CodeBook;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{

    [Table("Edu_Notification")]
    public class Notification : TableModel
    {
        public virtual NotificationType NotificationType { get; set; }
        public virtual Guid ObjectId { get; set; }
        public virtual User User { get; set; }
        public virtual bool IsNew { get; set; } = true;
        public virtual DateTime AddDate { get; set; }
    }
}
