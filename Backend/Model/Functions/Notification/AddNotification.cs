using System;

namespace Model.Functions.Notification
{
    public class AddNotification
    {
        public Guid NotificationTypeId { get; set; }
        public Guid ObjectId { get; set; }
        public Guid UserId { get; set; }
        public bool IsNew { get; set; } = true;
        public DateTime AddDateTime { get; set; } = DateTime.Now;
    }
}
