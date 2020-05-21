using Model.Functions.Branch;
using System.Collections.Generic;
using WebModel.BranchDto;

namespace EduFacade.BranchFacade.Convertor
{
    public interface IBranchConvertor
    {
        AddBranch ConvertToBussinessEntity(AddBranchDto addBranchDto);
        UpdateBranch ConvertToBussinessEntity(UpdateBranchDto updateBranchDto);
        IEnumerable<GetAllBranchInOrganizationDto> ConvertToWebModel(IEnumerable<GetAllBranchInOrganization> getAllBranchInOrganizations);
        GetBranchDetailDto ConvertToWebModel(GetBranchDetail getBranchDetail);
    }
}
