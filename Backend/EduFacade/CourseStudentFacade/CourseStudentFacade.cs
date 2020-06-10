using Core.DataTypes;
using Core.Extension;
using EduFacade.CourseStudentFacade.Convertor;
using EduServices.CodeBookService;
using EduServices.CourseStudentService;
using EduServices.NotificationService;
using EduServices.OrganizationRoleService;
using EduServices.RoleService;
using EduServices.UserService;
using Model.Functions.Notification;
using Model.Functions.User;
using Model.Functions.UserInOrganization;
using Model.Tables.CodeBook;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;
using System.Linq;
using WebModel.StudentDto;

namespace EduFacade.CourseStudentFacade
{
    public class CourseStudentFacade : BaseFacade, ICourseStudentFacade
    {
        private readonly ICourseStudentService _courseStudentService;
        private readonly ICourseStudentConvertor _courseStudentConvertor;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IOrganizationRoleService _organizationRoleService;
        private readonly INotificationService _notificationService;
        private readonly ICodeBookService _codeBooService;
        private readonly HashSet<NotificationType> _notificationTypes;

        public CourseStudentFacade(ICourseStudentService courseStudentService, ICourseStudentConvertor courseStudentConvertor, IUserService userService, IRoleService roleService, IOrganizationRoleService organizationRoleService, INotificationService notificationService, ICodeBookService codeBooService)
        {
            _courseStudentService = courseStudentService;
            _courseStudentConvertor = courseStudentConvertor;
            _userService = userService;
            _roleService = roleService;
            _organizationRoleService = organizationRoleService;
            _notificationService = notificationService;
            _codeBooService = codeBooService;
            _notificationTypes = _codeBooService.GetCodeBookItems<NotificationType>();
        }
        private Result Validate(AddStudentToCourseTermDto addStudentToCourseDto)
        {
            Result result = new Result();
            _courseStudentService.ValidateStudentCount(addStudentToCourseDto.CourseTermId, result);
            //_courseStudentService.IsTermStudent(addStudentToCourseDto.CourseTermId, addStudentToCourseDto.UserId, result);
            return result;
        }

        public Result AddStudentToCourseTerm(AddStudentToCourseTermDto addStudentToCourseTermDto, Guid organizationId)
        {
            Result result = Validate(addStudentToCourseTermDto);
            if (result.IsOk)
            {
                foreach (string email in addStudentToCourseTermDto.UserEmail)
                {
                    if (email.IsValidEmail())
                    {
                        GetUserDetail user = _userService.GetUserDetail(email);
                        if (user == null)
                        {
                            _userService.AddUserByEmail(email, _roleService.GetUserRole(UserRoleValues.REGISTERED_USER));
                            user = _userService.GetUserDetail(email);

                            _organizationRoleService.AddUserToOrganization(new AddUserToOrganization()
                            {
                                OrganizationId = organizationId,
                                OrganizationRoleId = _organizationRoleService.GetOrganizationRoles().FirstOrDefault(x => x.SystemIdentificator == OrganizationRoleValue.STUDENT).Id,
                                UserId = user.Id
                            });
                            _notificationService.AddNotification(new AddNotification()
                            {
                                IsNew = true,
                                NotificationTypeId = _notificationTypes.FirstOrDefault(x => x.SystemIdentificator == NotificationTypeValues.INVITE_TO_ORGANIZATION).Id,
                                ObjectId = organizationId,
                                UserId = user.Id
                            });
                        }
                        _courseStudentService.AddStudentToCourseTerm(new Model.Functions.CourseStudent.AddStudentToCourseTerm()
                        {
                            CourseTermId = addStudentToCourseTermDto.CourseTermId,
                            UserId = _organizationRoleService.GetAllUserInOrganization(organizationId).FirstOrDefault(x=> x.UserEmail == email).Id
                        });
                        _notificationService.AddNotification(new AddNotification()
                        {
                            IsNew = true,
                            NotificationTypeId = _notificationTypes.FirstOrDefault(x => x.SystemIdentificator == NotificationTypeValues.ADD_STUDENT_TO_COURSE_TERM).Id,
                            ObjectId = addStudentToCourseTermDto.CourseTermId,
                            UserId = user.Id
                        });
                    }
                }


            }
            return result;
        }

        public void DeleteStudentFromCourseTerm(Guid studentCourseTermId)
        {
            _courseStudentService.DeleteStudentFromCourseTerm(studentCourseTermId);
        }

        public List<GetAllStudentInCourseTermDto> GetAllStudentInCourseTerm(Guid courseTermId)
        {
            return _courseStudentConvertor.ConvertToWebModel(_courseStudentService.GetAllStudentInCourseTerm(courseTermId));
        }
    }
}
