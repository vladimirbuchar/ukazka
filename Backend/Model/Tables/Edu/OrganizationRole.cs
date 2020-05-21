using Model.Tables.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    public struct OrganizationRoleValue
    {
        public const string ORGANIZATION_OWNER = "ORGANIZATION_OWNER";
        public const string ORGANIZATION_ADMINISTATOR = "ORGANIZATION_ADMINISTATOR";
        public const string COURSE_ADMINISTATOR = "COURSE_ADMINISTATOR";
        public const string COURSE_EDITOR = "COURSE_EDITOR";
        public const string LECTOR = "LECTOR";
        public const string STUDENT = "STUDENT";
    }
    [Table("Edu_OrganizationRole")]
    public class OrganizationRole : TableModel
    {
        public virtual BasicInformation BasicInformation { get; set; }
        public virtual int Priority { get; set; }


    }
}
