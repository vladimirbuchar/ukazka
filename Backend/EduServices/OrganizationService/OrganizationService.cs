using Core.DataTypes;
using Core.Extension;
using EduRepository.OrganizationRepository;
using Model.Functions.Organization;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;

namespace EduServices.OrganizationService
{
    public class OrganizationService : BaseService, IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;
        public OrganizationService(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public void DeleteOrganization(Guid organizationId)
        {
            _organizationRepository.DeleteEntity<Organization>(organizationId);
        }

        public IEnumerable<GetAllOrganizations> GetOrganizationList()
        {
            return _organizationRepository.GetAllOrganizations();
        }

        public GetOrganizationDetail GetOrganizationDetail(Guid organizationId)
        {
            return _organizationRepository.GetOrganizationDetail(organizationId);
        }
        public HashSet<GetOrganizationAddress> GetOrganizationAddress(Guid organizationId)
        {
            return _organizationRepository.GetOrganizationAddress(organizationId);
        }

        public void UpdateOrganization(UpdateOrganization updateOrganization)
        {
            _organizationRepository.UpdateOrganization(updateOrganization);
        }

        public IEnumerable<GetMyOrganizations> GetMyOrganizations(Guid userId)
        {
            return _organizationRepository.GetMyOrganizations(userId);
        }

        public void ValidateOrganizationName(string name, Result validate)
        {
            if (name.IsNullOrEmptyWithTrim())
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "ORGANIZATION", "ORGANIZATION_NAME_IS_EMPTY"));
            }
        }
        public void ValidateUri(string uri, Result validate)
        {
            if (!uri.IsNullOrEmptyWithTrim())
            {
                if (!uri.IsValidUri())
                {
                    validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "ORGANIZATION", "URI_IS_NOT_VALID"));
                }
            }
        }
        public void ValidateEmail(string email, Result validate)
        {
            if (!email.IsNullOrEmptyWithTrim())
            {
                if (!email.IsValidEmail())
                {
                    validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "ORGANIZATION", "EMAIL_IS_NOT_VALID"));
                }
            }
        }
        public void ValidatePhoneNumber(string phoneNumber, Result validate)
        {
            if (!phoneNumber.IsNullOrEmptyWithTrim())
            {
                if (!phoneNumber.IsValidPhoneNumber())
                {
                    validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "ORGANIZATION", "PHONE_NUMBER_IS_NOT_VALID"));
                }
            }
        }

        public Guid AddOrganization(AddOrganization addOrganization)
        {
            return _organizationRepository.AddOrganization(addOrganization);
        }
    }
}
