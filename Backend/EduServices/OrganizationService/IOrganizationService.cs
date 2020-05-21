using Core.DataTypes;
using Model.Functions.Organization;
using System;
using System.Collections.Generic;

namespace EduServices.OrganizationService
{
    public interface IOrganizationService : IBaseService
    {
        /// <summary>
        /// create new organization in system
        /// </summary>
        /// <param name="create"></param>
        /// <returns></returns>
        Guid AddOrganization(AddOrganization addOrganization);

        /// <summary>
        /// update information about existing organization
        /// </summary>
        /// <param name="id"></param>
        /// <param name="create"></param>
        void UpdateOrganization(UpdateOrganization updateOrganization);
        /// <summary>
        /// get list with all register organization in system
        /// </summary>
        /// <returns></returns>
        IEnumerable<GetAllOrganizations> GetOrganizationList();
        /// <summary>
        /// return more information about select organization
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        GetOrganizationDetail GetOrganizationDetail(Guid ogranizationId);
        /// <summary>
        /// remove existing organization
        /// </summary>
        /// <param name="id"></param>
        void DeleteOrganization(Guid ogranizationId);
        /// <summary>
        /// return all organization, when i am register
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<GetMyOrganizations> GetMyOrganizations(Guid userId);
        void ValidateOrganizationName(string name, Result validate);
        void ValidateUri(string uri, Result validate);
        void ValidateEmail(string email, Result validate);
        void ValidatePhoneNumber(string phoneNumber, Result validate);
        HashSet<GetOrganizationAddress> GetOrganizationAddress(Guid organizationId);
    }
}
