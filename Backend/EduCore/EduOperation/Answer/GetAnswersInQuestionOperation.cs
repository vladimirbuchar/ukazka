using EduCore.DataTypes;

namespace EduCore.EduOperation.Answer
{
    public class GetAnswersInQuestionOperation : BaseOperation
    {
        public GetAnswersInQuestionOperation() : base("GET_ANSWERS_IN_QUESTION")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
            CourseEditor = true;
        }
    }
}