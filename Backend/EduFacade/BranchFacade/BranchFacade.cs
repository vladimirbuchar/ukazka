using Core.DataTypes;
using EduFacade.BranchFacade.Convertor;
using EduServices.BranchService;
using Model.Functions.Branch;
using System;
using System.Collections.Generic;
using WebModel.BranchDto;

namespace EduFacade.BranchFacade
{
    public class BranchFacade : BaseFacade, IBranchFacade
    {
        private readonly IBranchService _branchService;
        private readonly IBranchConvertor _branchConvertor;


        public BranchFacade(IBranchService service, IBranchConvertor branchConvertor)
        {
            _branchService = service;
            _branchConvertor = branchConvertor;
        }
        public Result AddBranch(AddBranchDto addBranchDto)
        {
            Result result = Validate(addBranchDto);
            if (result.IsOk)
            {
                AddBranch addBranch = _branchConvertor.ConvertToBussinessEntity(addBranchDto);
                _branchService.AddBranch(addBranch);
            }
            return result;
        }
        private Result Validate(AddBranchDto addBranchDto)
        {
            Result validate = new Result();
            _branchService.ValidateEmail(addBranchDto.ContactInformation.Email, validate);
            _branchService.ValidateUri(addBranchDto.ContactInformation.WWW, validate);
            _branchService.ValidatePhoneNumber(addBranchDto.ContactInformation.PhoneNumber, validate);
            return validate;
        }

        private Result Validate(UpdateBranchDto updateBranchDto)
        {
            Result validate = new Result();
            _branchService.ValidateEmail(updateBranchDto.ContactInformation.Email, validate);
            _branchService.ValidateUri(updateBranchDto.ContactInformation.WWW, validate);
            _branchService.ValidatePhoneNumber(updateBranchDto.ContactInformation.PhoneNumber, validate);
            return validate;
        }

        public void DeleteBranch(Guid branchId)
        {
            _branchService.DeleteBranch(branchId);
        }

        public IEnumerable<GetAllBranchInOrganizationDto> GetAllBranchInOrganization(Guid organizationId)
        {
            return _branchConvertor.ConvertToWebModel(_branchService.GetAllBranchInOrganization(organizationId));
        }

        public GetBranchDetailDto GetBranchDetail(Guid branchId)
        {
            return _branchConvertor.ConvertToWebModel(_branchService.GetBranchDetail(branchId));
        }

        public Result UpdateBranch(UpdateBranchDto updateBranchDto)
        {
            Result validate = Validate(updateBranchDto);
            if (validate.IsOk)
            {
                UpdateBranch updateBranch = _branchConvertor.ConvertToBussinessEntity(updateBranchDto);
                _branchService.UpdateBranch(updateBranch);
            }
            return validate;
        }
    }
}
