using EduCore.DataTypes;

namespace EduCore.EduOperation.BankOfQuestion
{
    public class GetBankOfQuestionInOrganizationOperation : BaseOperation
    {
        public GetBankOfQuestionInOrganizationOperation() : base("GET_BANK_OF_QUESTION_IN_ORGANIZATION")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
            CourseEditor = true;
        }
    }
}