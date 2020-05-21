using EduCore.DataTypes;

namespace EduCore.EduOperation.BankOfQuestion
{
    public class UpdateBankOfQuestionOperation : BaseOperation
    {
        public UpdateBankOfQuestionOperation() : base("UPDATE_BANK_OF_QUESTION")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
            CourseEditor = true;
        }
    }
}