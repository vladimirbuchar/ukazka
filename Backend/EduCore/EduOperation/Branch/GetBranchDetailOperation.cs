using EduCore.DataTypes;

namespace EduCore.EduOperation.Branch
{
    public class GetBranchDetailOperation : BaseOperation
    {
        public GetBranchDetailOperation() : base("GET_BRANCH_DETAIL_OPERATION")
        {
            OrganizationAdministrator = true;
        }
    }
}