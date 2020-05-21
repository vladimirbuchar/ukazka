using EduCore.DataTypes;

namespace EduCore.EduOperation.Branch
{
    public class AddBranchOperation : BaseOperation
    {
        public AddBranchOperation() : base("ADD_BRANCH")
        {
            OrganizationAdministrator = true;
        }
    }
}