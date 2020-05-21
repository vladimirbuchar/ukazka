using System;
using System.Collections.Generic;

namespace Model.Functions.Notification
{
    public class GetMyNotification : SqlFunction
    {
        public GetMyNotification()
        {
            Data = new Dictionary<string, string>();
        }
        public Guid Id { get; set; }
        public string NotificationIdentificator { get; set; }
        public Guid ObjectId { get; set; }
        public Dictionary<string, string> Data { get; set; }
        public bool IsNew { get; set; }
        public DateTime AddDate { get; set; }
    }
}
