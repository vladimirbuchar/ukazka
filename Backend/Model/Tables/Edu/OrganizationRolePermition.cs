using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_OrganizationRolePermition")]
    public class OrganizationRolePermition : TableModel
    {
        [Column("PermitionIdentificator")]
        public virtual string PermitionIdentificator { get; set; }
        public virtual OrganizationRole OrganizationRole { get; set; }

    }
}
