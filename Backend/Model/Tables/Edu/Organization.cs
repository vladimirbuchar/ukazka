using Model.Tables.CodeBook;
using Model.Tables.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_Organization")]
    public class Organization : TableModel
    {
        [Column("CanSendCourseInquiry")]
        public virtual bool CanSendCourseInquiry { get; set; }
        public virtual BasicInformation BasicInformation { get; set; }
        public virtual License License { get; set; }
        public virtual ContactInformation ContactInformation { get; set; }
        public virtual ICollection<Branch> Branch { get; set; }
        public virtual ICollection<Job> Job { get; set; }
        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<BankOfQuestion> BankOfQuestions { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
