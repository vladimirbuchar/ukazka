using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.CodeBook
{
    public struct NotificationTypeValues
    {
        public const string INVITE_TO_ORGANIZATION = "INVITE_TO_ORGANIZATION";
    }
    [Table("Cb_NotificationType")]
    public class NotificationType : CodeBook
    {
    }
}
