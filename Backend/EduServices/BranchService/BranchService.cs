using Core.DataTypes;
using Core.Extension;
using EduRepository.BranchRepository;
using Model.Functions.Branch;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;

namespace EduServices.BranchService
{
    public class BranchService : BaseService, IBranchService
    {
        private readonly IBranchRepository _branchRepository;
        public BranchService(IBranchRepository repository)
        {
            _branchRepository = repository;
        }
        public void AddBranch(AddBranch addBranch)
        {
            _branchRepository.AddBranch(addBranch);
        }

        public void UpdateBranch(UpdateBranch updateBranch)
        {
            _branchRepository.UpdateBranch(updateBranch);
        }

        public IEnumerable<GetAllBranchInOrganization> GetAllBranchInOrganization(Guid organizationId)
        {
            return _branchRepository.GetAllBranchInOrganization(organizationId);
        }
        public GetBranchDetail GetBranchDetail(Guid branchId)
        {
            return _branchRepository.GetBranchDetail(branchId);
        }

        public void DeleteBranch(Guid branchId)
        {
            _branchRepository.DeleteEntity<Branch>(branchId);
        }
        public void ValidateEmail(string email, Result validate)
        {
            if (!email.IsNullOrEmptyWithTrim())
            {
                if (!email.IsValidEmail())
                {
                    validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "BRANCH", "EMAIL_IS_NOT_VALID"));
                }
            }
        }
        public void ValidateUri(string uri, Result validate)
        {
            if (!uri.IsNullOrEmptyWithTrim())
            {
                if (!uri.IsValidUri())
                {
                    validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "BRANCH", "IS_NOT_VALID_URI"));
                }
            }
        }

        public void ValidatePhoneNumber(string phoneNumber, Result validate)
        {
            if (!phoneNumber.IsNullOrEmptyWithTrim())
            {
                if (!phoneNumber.IsValidPhoneNumber())
                {
                    validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "BRANCH", "IS_NOT_VALID_URI"));
                }
            }
        }
    }
}
