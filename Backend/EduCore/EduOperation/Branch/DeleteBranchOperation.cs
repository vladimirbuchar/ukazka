using EduCore.DataTypes;

namespace EduCore.EduOperation.Branch
{
    public class DeleteBranchOperation : BaseOperation
    {
        public DeleteBranchOperation() : base("DELETE_BRANCH")
        {
            OrganizationAdministrator = true;
        }
    }
}