using EduCore.DataTypes;

namespace EduCore.EduOperation.Answer
{
    public class DeleteAnswerOperation : BaseOperation
    {
        public DeleteAnswerOperation() : base("DELETE_ANSWER")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
            CourseEditor = true;
        }
    }
}