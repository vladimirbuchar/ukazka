using EduCore.DataTypes;
using EduRepository.OrganizationRepository;
using EduRepository.OrganizationRoleRepository;
using Model.Functions.Organization;
using Model.Functions.UserInOrganization;
using Model.Tables.Edu;
using Model.Tables.Link;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.OrganizationRoleService
{
    public class OrganizationRoleService : BaseService, IOrganizationRoleService
    {
        private readonly IOrganizationRoleRepository _organizationRoleRepository;

        private readonly IOrganizationRepository _organizationRepository;
        public OrganizationRoleService(IOrganizationRoleRepository organizationRoleRepository, IOrganizationRepository organizationRepository)
        {
            _organizationRoleRepository = organizationRoleRepository;
            _organizationRepository = organizationRepository;
        }

        public void AddUserToOrganization(AddUserToOrganization addUserToOrganization)
        {
            _organizationRoleRepository.AddUserToOrganization(addUserToOrganization);
        }
        public List<GetUserOrganizationRole> GetUserOrganizationRole(Guid userId, Guid organizationId)
        {
            return _organizationRoleRepository.GetUserOrganizationRole(userId, organizationId);
        }

        public bool CheckPermition(Guid userId, Guid organizationId, OperationType operationType)
        {
            List<GetUserOrganizationRole> check = _organizationRoleRepository.GetUserOrganizationRole(userId, organizationId);
            if (check == null)
            {
                return false;
            }
            if (check.FirstOrDefault(x => x.IsOrganizationOwner()) != null)
            {
                return operationType.OrganizationOwner;
            }
            if (check.FirstOrDefault(x => x.IsOrganizationAdministrator()) != null)
            {
                return operationType.OrganizationAdministrator;
            }
            if (check.FirstOrDefault(x => x.IsCourseAdministrator()) != null)
            {
                return operationType.CourseAdministrator;
            }
            if (check.FirstOrDefault(x => x.IsCourseEditor()) != null)
            {
                return operationType.CourseEditor;
            }
            if (check.FirstOrDefault(x => x.IsLector()) != null)
            {
                return operationType.Lector;
            }
            if (check.FirstOrDefault(x => x.IsStudent()) != null)
            {
                return operationType.Student;
            }
            return false;
        }

        public void DeleteUserFromOrganization(Guid userInOrganizationId)
        {
            _organizationRepository.DeleteEntity<UserInOrganization>(userInOrganizationId);
        }

        public Guid GetOrganizationIdByBranch(Guid branchId)
        {
            return _organizationRepository.GetOrganizationIdByBranch(branchId);
        }
        public Guid GetOrganizationIdByClassRoom(Guid classRoomId)
        {
            return _organizationRepository.GetOrganizationIdByClassRoom(classRoomId);
        }
        public Guid GetOrganizationByCourseLesson(Guid courseLessonId)
        {
            return _organizationRepository.GetOrganizationByCourseLessonId(courseLessonId);
        }

        public Guid GetOrganizationIdByCourseId(Guid courseId)
        {
            return _organizationRepository.GetOrganizationByCourse(courseId);
        }

        public Guid GetOrganizationIdByTermId(Guid termId)
        {
            return _organizationRepository.GetOrganizationByTermId(termId);
        }

        public List<GetAllUserInOrganization> GetAllUserInOrganization(Guid organizationId)
        {
            return _organizationRoleRepository.GetAllUserInOrganization(organizationId);
        }

        public Guid GetOrganizationByUserInOrganization(Guid id)
        {
            return _organizationRepository.GetOrganizationByUserInOrganization(id);
        }
        public List<FindOrganization> FindOrganization(string findText)
        {
            return _organizationRepository.FindOrganization(findText);
        }

        public Guid GetOrganizationByCourseLessonItem(Guid courseLessonItemId)
        {
            return _organizationRepository.GetOrganizationByCourseLessonItemId(courseLessonItemId);
        }

        public Guid GetOrganizationIdByBankOfQuestion(Guid bankOfQuestionId)
        {
            return _organizationRepository.GetOrganizationIdByBankOfQuestion(bankOfQuestionId);
        }

        public Guid GetOrganizationIdByQuestion(Guid questionId)
        {
            return _organizationRepository.GetOrganizationIdByQuestion(questionId);
        }

        public Guid GetOrganizationByAnswer(Guid answerId)
        {
            return _organizationRepository.GetOrganizationByAnswer(answerId);
        }

        public HashSet<OrganizationRole> GetOrganizationRoles()
        {
            return _organizationRoleRepository.GetEntities<OrganizationRole>().OrderBy(x => x.Priority).ToHashSet();
        }

        public GetUserOrganizationRoleDetail GetUserOrganizationRoleDetail(Guid userInOrganizationId)
        {
            return _organizationRoleRepository.GetUserOrganizationRoleDetail(userInOrganizationId);
        }

        public void UpdateUserInOrganizationRole(UpdateUserInOrganizationRole updateUserInOrganizationRole)
        {
            _organizationRoleRepository.UpdateUserInOrganizationRole(updateUserInOrganizationRole);
        }

        public Guid GetOrganizationByStudentId(Guid studentId)
        {
            return _organizationRepository.GetOrganizationByStudent(studentId);
        }
    }
}
