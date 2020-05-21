using Core.DataTypes;
using Model.Functions.Branch;
using System;
using System.Collections.Generic;

namespace EduServices.BranchService
{
    public interface IBranchService : IBaseService
    {
        /// <summary>
        /// create new branch in organization 
        /// </summary>
        /// <param name="branch"></param>
        void AddBranch(AddBranch branch);
        /// <summary>
        /// method for update existing branch 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="branch"></param>
        void UpdateBranch(UpdateBranch updateBranch);
        /// <summary>
        /// get all exist branch in organization 
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        IEnumerable<GetAllBranchInOrganization> GetAllBranchInOrganization(Guid organizationId);

        /// <summary>
        /// get more information about branch
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        GetBranchDetail GetBranchDetail(Guid branchId);
        /// <summary>
        /// delete exist branch
        /// </summary>
        /// <param name="id"></param>
        void DeleteBranch(Guid branchId);
        void ValidateEmail(string email, Result validate);
        void ValidateUri(string uri, Result validate);
        void ValidatePhoneNumber(string phoneNumber, Result validate);


    }
}
