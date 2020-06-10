using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.CodeBook
{
    public struct NotificationTypeValues
    {
        public const string INVITE_TO_ORGANIZATION = "INVITE_TO_ORGANIZATION";
        public const string ADD_STUDENT_TO_COURSE_TERM = "ADD_STUDENT_TO_COURSE_TERM";
    }
    [Table("Cb_NotificationType")]
    public class NotificationType : CodeBook
    {
    }
}
