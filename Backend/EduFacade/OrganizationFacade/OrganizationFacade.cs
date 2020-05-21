using Core.DataTypes;
using Core.Extension;
using EduFacade.OrganizationFacade.Convertor;
using EduServices.CodeBookService;
using EduServices.NotificationService;
using EduServices.OrganizationRoleService;
using EduServices.OrganizationService;
using EduServices.RoleService;
using EduServices.UserService;
using Model.Functions.Organization;
using Model.Functions.User;
using Model.Functions.UserInOrganization;
using Model.Tables.CodeBook;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;
using System.Linq;
using WebModel.OrganizationDto;

namespace EduFacade.OrganizationFacade
{
    public class OrganizationFacade : BaseFacade, IOrganizationFacade
    {
        private readonly IOrganizationService _organizationService;
        private readonly IOrganizationRoleService _organizationRoleService;
        private readonly IOrganizationConvertor _organizationConvertor;
        private readonly IUserService _userService;
        private readonly INotificationService _notificationService;
        private readonly ICodeBookService _codeBooService;
        private readonly HashSet<NotificationType> _notificationTypes;
        private readonly IRoleService _roleService;
        public OrganizationFacade(IRoleService roleService, ICodeBookService codeBookService, INotificationService notificationService, IUserService userService, IOrganizationService organizationService, IOrganizationRoleService organizationRoleService, IOrganizationConvertor organizationConvertor)
        {
            _organizationService = organizationService;
            _organizationRoleService = organizationRoleService;
            _organizationConvertor = organizationConvertor;
            _userService = userService;
            _notificationService = notificationService;
            _codeBooService = codeBookService;
            _notificationTypes = _codeBooService.GetCodeBookItems<NotificationType>();
            _roleService = roleService;
        }

        public Result AddOrganization(Guid userId, AddOrganizationDto addOrganizationDto)
        {
            Result validate = Validate(addOrganizationDto);
            if (validate.IsOk)
            {
                AddOrganization addOrganization = _organizationConvertor.ConvertToBussinessEntity(addOrganizationDto, userId);
                return new Result<Guid>()
                {
                    Data = _organizationService.AddOrganization(addOrganization)
                };
            }
            return validate;
        }

        public void AddUserToOrganization(AddUserToOrganizationDto addUserToOrganizationDto)
        {
            foreach (string email in addUserToOrganizationDto.UserEmails.Distinct())
            {
                if (email.IsValidEmail())
                {
                    GetUserDetail user = _userService.GetUserDetail(email);
                    if (user == null)
                    {
                        _userService.AddUserByEmail(email, _roleService.GetUserRole(UserRoleValues.REGISTERED_USER));
                        user = _userService.GetUserDetail(email);

                    }
                    _organizationRoleService.AddUserToOrganization(new Model.Functions.UserInOrganization.AddUserToOrganization()
                    {
                        OrganizationId = addUserToOrganizationDto.OrganizationId,
                        OrganizationRoleId = addUserToOrganizationDto.OrganizationRoleId,
                        UserId = user.Id
                    });
                    _notificationService.AddNotification(new Model.Functions.Notification.AddNotification()
                    {
                        IsNew = true,
                        NotificationTypeId = _notificationTypes.FirstOrDefault(x => x.SystemIdentificator == NotificationTypeValues.INVITE_TO_ORGANIZATION).Id,
                        ObjectId = addUserToOrganizationDto.OrganizationId,
                        UserId = user.Id
                    });
                }

            }
        }

        public void DeleteOrganization(Guid organizationId)
        {
            _organizationService.DeleteOrganization(organizationId);
        }

        public void DeleteUserFromOrganization(Guid userInOrganization)
        {
            _organizationRoleService.DeleteUserFromOrganization(userInOrganization);
        }

        public List<FindOrganizationDto> FindOrganization(string findText)
        {
            return _organizationConvertor.ConvertToWebModel(_organizationRoleService.FindOrganization(findText));
        }

        public List<GetAllUserInOrganizationDto> GetAllUserInOrganization(Guid organizationId)
        {
            return _organizationConvertor.ConvertToWebModel(_organizationRoleService.GetAllUserInOrganization(organizationId));
        }


        public IEnumerable<GetMyOrganizationsDto> GetMyOrganizations(Guid userId)
        {
            return _organizationConvertor.ConvertToWebModel(_organizationService.GetMyOrganizations(userId));
        }

        public GetOrganizationDetailDto GetOrganizationDetail(Guid organizationId)
        {
            GetOrganizationDetail getOrganizationDetail = _organizationService.GetOrganizationDetail(organizationId);
            HashSet<GetOrganizationAddress> organizationAddresses = _organizationService.GetOrganizationAddress(organizationId);
            return _organizationConvertor.ConvertToWebModel(getOrganizationDetail, organizationAddresses);
        }

        public GetOrganizationDetailWebDto GetOrganizationDetailWeb(Guid organizationId)
        {
            return _organizationConvertor.ConvertToWebModelWeb(_organizationService.GetOrganizationDetail(organizationId));
        }

        public IEnumerable<GetOrganizationListDto> GetOrganizationList()
        {
            return _organizationConvertor.ConvertToWebModel(_organizationService.GetOrganizationList());
        }

        public HashSet<GetOrganizationRolesDto> GetOrganizationRoles()
        {
            HashSet<OrganizationRole> organizationRoles = _organizationRoleService.GetOrganizationRoles();
            return _organizationConvertor.ConvertToWebModel(organizationRoles);

        }

        public GetUserOrganizationRoleDetailDto GetUserOrganizationRoleDetail(Guid userInOrganizationId)
        {
            return new GetUserOrganizationRoleDetailDto()
            {
                Id = _organizationRoleService.GetUserOrganizationRoleDetail(userInOrganizationId).OrganizationRoleId
            };
        }

        public Result UpdateOrganization(UpdateOrganizationDto updateOrganizationDto)
        {
            Result result = Validate(updateOrganizationDto);
            if (result.IsOk)
            {
                UpdateOrganization updateOrganization = _organizationConvertor.ConvertToBussinessEntity(updateOrganizationDto);
                _organizationService.UpdateOrganization(updateOrganization);
            }
            return result;
        }

        public void UpdateUserInOrganizationRole(UpdateUserInOrganizationRoleDto updateUserInOrganizationRoleDto)
        {
            UpdateUserInOrganizationRole updateUserInOrganizationRole = _organizationConvertor.ConvertToBussinessEntity(updateUserInOrganizationRoleDto);
            _organizationRoleService.UpdateUserInOrganizationRole(updateUserInOrganizationRole);
        }

        private Result Validate(AddOrganizationDto addOrganizationDto)
        {
            Result validate = new Result();
            _organizationService.ValidateOrganizationName(addOrganizationDto.Name, validate);
            _organizationService.ValidateUri(addOrganizationDto.ContactInformation.WWW, validate);
            _organizationService.ValidateEmail(addOrganizationDto.ContactInformation.Email, validate);
            _organizationService.ValidatePhoneNumber(addOrganizationDto.ContactInformation.PhoneNumber, validate);
            return validate;
        }
        private Result Validate(UpdateOrganizationDto updateOrganizationDto)
        {
            Result validate = new Result();
            _organizationService.ValidateOrganizationName(updateOrganizationDto.Name, validate);
            _organizationService.ValidateUri(updateOrganizationDto.ContactInformation.WWW, validate);
            _organizationService.ValidateEmail(updateOrganizationDto.ContactInformation.Email, validate);
            _organizationService.ValidatePhoneNumber(updateOrganizationDto.ContactInformation.PhoneNumber, validate);
            return validate;
        }
    }
}
