using EduCore.DataTypes;

namespace EduCore.EduOperation.BankOfQuestion
{
    public class GetBankOfQuestionDetailOperation : BaseOperation
    {
        public GetBankOfQuestionDetailOperation() : base("GET_BANK_OF_QUESTION_DETAIL")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
            CourseEditor = true;
        }
    }
}
