using Model.Functions.BankOfQuestion;
using System;
using System.Collections.Generic;
namespace EduRepository.CourseRepository
{
    public interface IBankOfQuestionRepository : IBaseRepository
    {
        List<GetBankOfQuestionInOrganization> GetBankOfQuestionInOrganization(Guid organizationId);
        GetBankOfQuestionDetail GetBankOfQuestionDetail(Guid courseId);
        void AddBankOfQuestion(AddBankOfQuestion addBankOfQuestion);
        void UpdateBankOfQuestion(UpdateBankOfQuestion updateBankOfQuestion);
    }
}
