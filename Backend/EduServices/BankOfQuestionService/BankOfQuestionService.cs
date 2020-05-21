using EduRepository.CourseRepository;
using Model.Functions.BankOfQuestion;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;

namespace EduServices.CourseService
{
    public class BankOfQuestionService : BaseService, IBankOfQuestionService
    {
        private readonly IBankOfQuestionRepository _bankOfQuestionRepository;

        public BankOfQuestionService(IBankOfQuestionRepository bankOfQuestionRepository)
        {
            _bankOfQuestionRepository = bankOfQuestionRepository;

        }

        public void AddBankOfQuestion(AddBankOfQuestion addBankOfQuestion)
        {
            _bankOfQuestionRepository.AddBankOfQuestion(addBankOfQuestion);
        }

        public GetBankOfQuestionDetail GetBankOfQuestionDetail(Guid bankOfQuestionId)
        {
            return _bankOfQuestionRepository.GetBankOfQuestionDetail(bankOfQuestionId);
        }

        public void DeleteBankOfQuestion(Guid bankOfQuestionId)
        {
            _bankOfQuestionRepository.DeleteEntity<BankOfQuestion>(bankOfQuestionId);
        }

        public void UpdateBankOfQuestion(UpdateBankOfQuestion updateBankOfQuestion)
        {
            _bankOfQuestionRepository.UpdateBankOfQuestion(updateBankOfQuestion);
        }

        public List<GetBankOfQuestionInOrganization> GetBankOfQuestionInOrganization(Guid orgazizationId)
        {
            return _bankOfQuestionRepository.GetBankOfQuestionInOrganization(orgazizationId);
        }
    }
}
