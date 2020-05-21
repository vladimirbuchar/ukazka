using EduCore.DataTypes;

namespace EduCore.EduOperation.Answer
{
    public class AddAnswerOperation : BaseOperation
    {
        public AddAnswerOperation() : base("ADD_ANSWER")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
            CourseEditor = true;
        }
    }

}