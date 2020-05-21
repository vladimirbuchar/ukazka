using EduCore.DataTypes;
using Model.Functions.Organization;
using Model.Functions.UserInOrganization;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;

namespace EduServices.OrganizationRoleService
{
    public interface IOrganizationRoleService : IBaseService
    {
        /// <summary>
        /// add user to organization
        /// </summary>
        /// <param name="roleIndetificator"></param>
        void AddUserToOrganization(AddUserToOrganization addUserToOrganization);
        /// <summary>
        /// check user permition
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="organizationId"></param>
        /// <param name="operationType"></param>
        /// <returns></returns>
        bool CheckPermition(Guid userId, Guid organizationId, OperationType operationType);
        /// <summary>
        /// return organization id by branch
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>
        Guid GetOrganizationIdByBranch(Guid branchId);
        /// <summary>
        /// return organization id by class room
        /// </summary>
        /// <param name="classRoomId"></param>
        /// <returns></returns>
        Guid GetOrganizationIdByClassRoom(Guid classRoomId);
        /// <summary>
        /// retrun organization id by course
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        Guid GetOrganizationIdByCourseId(Guid courseId);
        /// <summary>
        /// return organization id by course term
        /// </summary>
        /// <param name="termId"></param>
        /// <returns></returns>
        Guid GetOrganizationIdByTermId(Guid termId);
        /// <summary>
        /// remove all permitions
        /// </summary>
        void DeleteUserFromOrganization(Guid oid);
        List<GetAllUserInOrganization> GetAllUserInOrganization(Guid organizationId);
        Guid GetOrganizationByUserInOrganization(Guid id);
        Guid GetOrganizationIdByBankOfQuestion(Guid bankOfQuestion);
        List<FindOrganization> FindOrganization(string findText);
        Guid GetOrganizationByCourseLesson(Guid courseLessonId);
        Guid GetOrganizationByCourseLessonItem(Guid courseLessonItemId);
        Guid GetOrganizationIdByQuestion(Guid questionId);
        Guid GetOrganizationByAnswer(Guid answerId);
        HashSet<OrganizationRole> GetOrganizationRoles();
        GetUserOrganizationRoleDetail GetUserOrganizationRoleDetail(Guid userInOrganizationId);
        void UpdateUserInOrganizationRole(UpdateUserInOrganizationRole updateUserInOrganizationRole);
        List<GetUserOrganizationRole> GetUserOrganizationRole(Guid userId, Guid organizationId);
    }
}
