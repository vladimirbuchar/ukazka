using EduServices.CodeBookService;
using Model.Functions.Organization;
using Model.Functions.Shared;
using Model.Functions.UserInOrganization;
using Model.Tables.CodeBook;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;
using System.Linq;
using WebModel.OrganizationDto;
using WebModel.Shared;

namespace EduFacade.OrganizationFacade.Convertor
{
    public class OrganizationConvertor : IOrganizationConvertor
    {
        private readonly ICodeBookService _codeBookService;
        private readonly HashSet<AddressType> _addressTypes;
        public OrganizationConvertor(ICodeBookService codeBookService)
        {
            _codeBookService = codeBookService;
            _addressTypes = _codeBookService.GetCodeBookItems<AddressType>();
        }
        public AddOrganization ConvertToBussinessEntity(AddOrganizationDto addOrganizationDto, Guid userId)
        {
            HashSet<FAddress> addresses = new HashSet<FAddress>();
            foreach (AddressDto item in addOrganizationDto.Addresses)
            {
                addresses.Add(new FAddress()
                {
                    AddressTypeId = item.AddressTypeId,
                    City = item.City,
                    CountryId = item.CountryId,
                    HouseNumber = item.HouseNumber,
                    Region = item.Region,
                    Street = item.Street,
                    ZipCode = item.ZipCode,
                    AddressTypeIdentificator = _addressTypes.FirstOrDefault(x => x.Id == item.AddressTypeId)?.SystemIdentificator
                });
            }
            return new AddOrganization()
            {
                CanSendCourseInquiry = addOrganizationDto.CanSendCourseInquiry,
                BasicInformationDescription = addOrganizationDto.Description,
                BasicInformationName = addOrganizationDto.Name,
                ContactInformationEmail = addOrganizationDto.ContactInformation.Email,
                ContactInformationPhoneNumber = addOrganizationDto.ContactInformation.PhoneNumber,
                ContactInformationWWW = addOrganizationDto.ContactInformation.WWW,
                OrganizationRoleIdentificator = OrganizationRoleValue.ORGANIZATION_OWNER,
                LicenseIdentificator = LicenseValues.FREE,
                UserId = userId,
                Addresses = addresses
            };
        }

        public UpdateOrganization ConvertToBussinessEntity(UpdateOrganizationDto updateOrganizationDto)
        {
            HashSet<FAddress> addresses = new HashSet<FAddress>();
            foreach (AddressDto item in updateOrganizationDto.Addresses)
            {
                addresses.Add(new FAddress()
                {
                    AddressTypeId = item.AddressTypeId,
                    City = item.City,
                    CountryId = item.CountryId,
                    HouseNumber = item.HouseNumber,
                    Region = item.Region,
                    Street = item.Street,
                    ZipCode = item.ZipCode,
                    AddressTypeIdentificator = _addressTypes.FirstOrDefault(x => x.Id == item.AddressTypeId)?.SystemIdentificator
                });
            }
            return new UpdateOrganization()
            {
                BasicInformationDescription = updateOrganizationDto.Description,
                BasicInformationName = updateOrganizationDto.Name,
                CanSendCourseInquiry = updateOrganizationDto.CanSendCourseInquiry,
                ContactInformationEmail = updateOrganizationDto.ContactInformation.Email,
                ContactInformationPhoneNumber = updateOrganizationDto.ContactInformation.PhoneNumber,
                ContactInformationWWW = updateOrganizationDto.ContactInformation.WWW,
                OrganizationId = updateOrganizationDto.Id,
                Addresses = addresses
            };
        }

        public AddUserToOrganization ConvertToBussinessEntity(AddUserToOrganizationDto adUserToOrganizationDto)
        {
            return new AddUserToOrganization()
            {
                OrganizationId = adUserToOrganizationDto.OrganizationId,
                OrganizationRoleId = adUserToOrganizationDto.OrganizationRoleId,
                //UserId = adUserToOrganizationDto.UserId
            };
        }

        public UpdateUserInOrganizationRole ConvertToBussinessEntity(UpdateUserInOrganizationRoleDto updateUserInOrganizationRoleDto)
        {
            return new UpdateUserInOrganizationRole()
            {
                Id = updateUserInOrganizationRoleDto.Id,
                OrganizationRoleId = updateUserInOrganizationRoleDto.OrganizationRoleId
            };
        }

        public IEnumerable<GetMyOrganizationsDto> ConvertToWebModel(IEnumerable<GetMyOrganizations> getMyOrganizations)
        {
            HashSet<GetMyOrganizationsDto> data = new HashSet<GetMyOrganizationsDto>();
            foreach (GetMyOrganizations item in getMyOrganizations)
            {
                data.Add(new GetMyOrganizationsDto()
                {
                    Id = item.Id,
                    IsOrganizationOwner = item.IsOrganizationOwner,
                    IsCourseAdministrator =item.IsCourseAdministrator,
                    IsCourseEditor =item.IsCourseEditor,
                    IsLector = item.IsLector,
                    IsOrganizationAdministrator = item.IsOrganizationAdministrator,
                    IsStudent =item.IsStudent,
                    Name = item.Name,
                    UserInOrganizationRoleId = item.UserInOrganizationRoleId
                });
            }
            return data;
        }

        public GetOrganizationDetailDto ConvertToWebModel(GetOrganizationDetail getOrganizationDetail, HashSet<GetOrganizationAddress> organizationAddresses)
        {
            HashSet<AddressDto> addresss = new HashSet<AddressDto>();
            foreach (GetOrganizationAddress item in organizationAddresses)
            {
                addresss.Add(new AddressDto()
                {
                    AddressTypeId = item.AddressTypeId,
                    City = item.City,
                    CountryId = item.CountryId,
                    HouseNumber = item.HouseNumber,
                    Region = item.Region,
                    Street = item.Street,
                    ZipCode = item.ZipCode
                });
            }
            return new GetOrganizationDetailDto()
            {
                Id = getOrganizationDetail.Id,
                Description = getOrganizationDetail.Description,
                Name = getOrganizationDetail.Name,
                ContactInformation = new WebModel.Shared.ContactInformationDto()
                {
                    Email = getOrganizationDetail.Email,
                    PhoneNumber = getOrganizationDetail.PhoneNumber,
                    WWW = getOrganizationDetail.WWW
                },
                CanSendCourseInquiry = getOrganizationDetail.CanSendCourseInquiry,
                LicenseId = getOrganizationDetail.LicenseId,
                Addresses = addresss
            };
        }

        public IEnumerable<GetOrganizationListDto> ConvertToWebModel(IEnumerable<GetAllOrganizations> getAllOrganizations)
        {
            List<GetOrganizationListDto> getAllOrganizationDtos = new List<GetOrganizationListDto>();
            foreach (GetAllOrganizations item in getAllOrganizations)
            {
                getAllOrganizationDtos.Add(new GetOrganizationListDto()
                {
                    Description = item.Description,
                    Id = item.Id,
                    Name = item.Name,
                });
            }
            return getAllOrganizationDtos;
        }

        public List<FindOrganizationDto> ConvertToWebModel(List<FindOrganization> findOrganizations)
        {
            List<FindOrganizationDto> data = new List<FindOrganizationDto>();
            foreach (FindOrganization item in findOrganizations)
            {
                data.Add(new FindOrganizationDto()
                {
                    City = item.City,
                    Country = item.Country,
                    HouseNumber = item.HouseNumber,
                    Id = item.Id,
                    OrganizationDescription = item.OrganizationDescription,
                    OrganizationName = item.OrganizationName,
                    Region = item.Region,
                    Street = item.Street
                });
            }
            return data;
        }

        public List<GetAllUserInOrganizationDto> ConvertToWebModel(List<GetAllUserInOrganization> getAllUserInOrganizations)
        {
            List<GetAllUserInOrganizationDto> data = new List<GetAllUserInOrganizationDto>();
            foreach (GetAllUserInOrganization item in getAllUserInOrganizations)
            {
                data.Add(new GetAllUserInOrganizationDto()
                {
                    FirstName = item.FirstName,
                    Id = item.Id,
                    LastName = item.LastName,
                    SecondName = item.SecondName,
                    UserRole = item.UserRole,
                    UserEmail = item.UserEmail
                });
            }
            return data;
        }

        public HashSet<GetOrganizationRolesDto> ConvertToWebModel(HashSet<OrganizationRole> organizationRoles)
        {
            HashSet<GetOrganizationRolesDto> data = new HashSet<GetOrganizationRolesDto>();
            foreach (OrganizationRole item in organizationRoles)
            {
                data.Add(new GetOrganizationRolesDto()
                {
                    RoleIndentificator = item.SystemIdentificator,
                    RoleId = item.Id
                });
            }
            return data;
        }

        public GetOrganizationDetailWebDto ConvertToWebModelWeb(GetOrganizationDetail getOrganizationDetail)
        {
            return new GetOrganizationDetailWebDto()
            {
                Id = getOrganizationDetail.Id,
                Description = getOrganizationDetail.Description,
                Name = getOrganizationDetail.Name,
                ContactInformation = new WebModel.Shared.ContactInformationDto()
                {
                    Email = getOrganizationDetail.Email,
                    PhoneNumber = getOrganizationDetail.PhoneNumber,
                    WWW = getOrganizationDetail.WWW
                }
            };
        }
    }
}
