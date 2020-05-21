using Model.Functions.BankOfQuestion;
using System;
using System.Collections.Generic;

namespace EduServices.CourseService
{
    public interface IBankOfQuestionService : IBaseService
    {
        /// <summary>
        /// create new course
        /// </summary>
        /// <param name="course"></param>
        void AddBankOfQuestion(AddBankOfQuestion addBankOfQuestion);

        /// <summary>
        /// update exists course
        /// </summary>
        /// <param name="course"></param>
        void UpdateBankOfQuestion(UpdateBankOfQuestion updateBankOfQuestion);

        /// <summary>
        /// get detail about course 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        GetBankOfQuestionDetail GetBankOfQuestionDetail(Guid bankOfQuestionId);

        /// <summary>
        /// delete course
        /// </summary>
        /// <param name="id"></param>
        void DeleteBankOfQuestion(Guid bankOfQuestionId);

        List<GetBankOfQuestionInOrganization> GetBankOfQuestionInOrganization(Guid orgazizationId);
    }
}
