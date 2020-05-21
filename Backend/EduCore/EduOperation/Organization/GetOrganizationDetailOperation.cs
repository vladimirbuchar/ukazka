using EduCore.DataTypes;

namespace EduCore.EduOperation.Organization
{
    public class GetOrganizationDetailOperation : BaseOperation
    {
        public GetOrganizationDetailOperation() : base("GET_ORGANIZATION_DETAIL",true)
        {
            OrganizationAdministrator = true;
        }
    }
}