using Core.DataTypes;
using System;
using System.Collections.Generic;
using WebModel.BranchDto;

namespace EduFacade.BranchFacade
{
    public interface IBranchFacade : IBaseFacade
    {
        Result AddBranch(AddBranchDto addBranchDto);
        IEnumerable<GetAllBranchInOrganizationDto> GetAllBranchInOrganization(Guid organizationId);
        void DeleteBranch(Guid branchId);
        GetBranchDetailDto GetBranchDetail(Guid branchId);
        Result UpdateBranch(UpdateBranchDto updateBranchDto);
    }
}
