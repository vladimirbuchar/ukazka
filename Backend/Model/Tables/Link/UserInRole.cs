using Model.Tables.Edu;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Link
{
    [Table("Link_UserInRole")]
    public class UserInRole : TableModel
    {
        public virtual User User { get; set; }
        public virtual UserRole UserRole { get; set; }
    }
}
