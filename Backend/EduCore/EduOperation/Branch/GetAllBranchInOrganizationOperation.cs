using EduCore.DataTypes;

namespace EduCore.EduOperation.Branch
{
    public class GetAllBranchInOrganizationOperation : BaseOperation
    {
        public GetAllBranchInOrganizationOperation() : base("GET_ALL_BRANCH_IN_ORGANIZATION")
        {
            OrganizationAdministrator = true;
        }
    }
}