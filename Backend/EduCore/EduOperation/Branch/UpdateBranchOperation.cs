using EduCore.DataTypes;

namespace EduCore.EduOperation.Branch
{
    public class UpdateBranchOperation : BaseOperation
    {
        public UpdateBranchOperation() : base("UPDATE_BRANCH")
        {
            OrganizationAdministrator = true;
        }
    }
}