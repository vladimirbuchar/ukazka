using EduCore.DataTypes;

namespace EduCore.EduOperation.Answer
{
    public class GetAnswerDetailOperation : BaseOperation
    {
        public GetAnswerDetailOperation() : base("GET_ANSWER_DETAIL")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
            CourseEditor = true;
        }
    }
}
