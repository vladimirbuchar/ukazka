using Model.Functions.Branch;
using System;
using System.Collections.Generic;

namespace EduRepository.BranchRepository
{
    public interface IBranchRepository : IBaseRepository
    {
        IEnumerable<GetAllBranchInOrganization> GetAllBranchInOrganization(Guid organizationId);
        GetBranchDetail GetBranchDetail(Guid branchId);
        void AddBranch(AddBranch addBranch);
        void UpdateBranch(UpdateBranch updateBranch);
    }
}
