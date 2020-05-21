using EduCore.DataTypes;

namespace EduCore.EduOperation.BankOfQuestion
{
    public class AddBankOfQuestionOperation : BaseOperation
    {
        public AddBankOfQuestionOperation() : base("ADD_BANK_OF_QUESTION")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
            CourseEditor = true;
        }
    }
}