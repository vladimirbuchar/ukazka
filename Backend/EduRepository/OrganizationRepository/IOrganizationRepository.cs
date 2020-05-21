using Model.Functions.License;
using Model.Functions.Organization;
using System;
using System.Collections.Generic;

namespace EduRepository.OrganizationRepository
{
    public interface IOrganizationRepository : IBaseRepository
    {
        Guid GetOrganizationIdByBranch(Guid branchId);
        Guid GetOrganizationIdByClassRoom(Guid classRoomId);
        Guid GetOrganizationByCourse(Guid courseId);
        Guid GetOrganizationByTermId(Guid termId);
        IEnumerable<GetAllOrganizations> GetAllOrganizations();
        IEnumerable<GetMyOrganizations> GetMyOrganizations(Guid userId);
        GetOrganizationDetail GetOrganizationDetail(Guid organizationId);
        GetLicenseByOrganization GetLicenseByOrganization(Guid organizationId);
        Guid GetOrganizationByUserInOrganization(Guid organizationUserId);
        Guid AddOrganization(AddOrganization addOrganization);
        void UpdateOrganization(UpdateOrganization updateOrganization);
        List<FindOrganization> FindOrganization(string findText);
        Guid GetOrganizationByCourseLessonId(Guid courseLessonId);
        Guid GetOrganizationByCourseLessonItemId(Guid courseLessonItemId);
        Guid GetOrganizationIdByBankOfQuestion(Guid bankOfQuestionId);
        Guid GetOrganizationIdByQuestion(Guid questionId);
        Guid GetOrganizationByAnswer(Guid answerId);
        HashSet<GetOrganizationAddress> GetOrganizationAddress(Guid organizationId);
    }
}
