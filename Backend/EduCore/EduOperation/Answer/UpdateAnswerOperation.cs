using EduCore.DataTypes;

namespace EduCore.EduOperation.Answer
{
    public class UpdateAnswerOperation : BaseOperation
    {
        public UpdateAnswerOperation() : base("UPDATE_ANSWER")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
            CourseEditor = true;
        }
    }
}