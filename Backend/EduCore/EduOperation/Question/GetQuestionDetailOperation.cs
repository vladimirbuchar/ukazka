using EduCore.DataTypes;

namespace EduCore.EduOperation.Question
{
    public class GetQuestionDetailOperation : BaseOperation
    {
        public GetQuestionDetailOperation() : base("GET_QUESTION_DETAIL")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
            CourseEditor = true;
        }
    }
}
