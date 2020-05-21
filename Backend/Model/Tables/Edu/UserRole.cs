using Model.Tables.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{

    public struct UserRoleValues
    {
        public const string REGISTERED_USER = "REGISTERED_USER";
    }
    [Table("Edu_UserRole")]
    public class UserRole : TableModel
    {
        public virtual BasicInformation BasicInformation { get; set; }
    }
}
