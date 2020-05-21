using EduCore.DataTypes;

namespace EduCore.EduOperation.Organization
{
    public class UpdateOrganizationOperation : BaseOperation
    {
        public UpdateOrganizationOperation() : base("UPDATE_ORGANIZATION")
        {
            OrganizationAdministrator = true;
        }
    }
}