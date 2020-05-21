using EduCore.DataTypes;

namespace EduCore.EduOperation.Question
{
    public class AddQuestionOperation : BaseOperation
    {
        public AddQuestionOperation() : base("ADD_QUESTION_OPERATION")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
            CourseEditor = true;
        }
    }
}