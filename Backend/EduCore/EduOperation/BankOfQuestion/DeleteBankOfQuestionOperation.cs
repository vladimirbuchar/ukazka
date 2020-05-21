using EduCore.DataTypes;

namespace EduCore.EduOperation.BankOfQuestion
{
    public class DeleteBankOfQuestionOperation : BaseOperation
    {
        public DeleteBankOfQuestionOperation() : base("DELETE_BANK_OF_QUESTION")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
            CourseEditor = true;
        }
    }
}