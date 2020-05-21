using EduCore.DataTypes;

namespace EduCore.EduOperation.Question
{
    public class GetQuestionsInBankOperation : BaseOperation
    {
        public GetQuestionsInBankOperation() : base("GET_QUESTIONS_IN_BANK")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
            CourseEditor = true;
        }
    }
}