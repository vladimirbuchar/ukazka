using Model.Tables.Edu;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Link
{

    [Table("Link_UserInOrganization")]
    public class UserInOrganization : TableModel
    {
        public virtual User User { get; set; }
        public virtual OrganizationRole OrganizationRole { get; set; }
        public virtual Organization Organization { get; set; }

    }
}
