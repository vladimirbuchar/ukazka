using EduCore.DataTypes;

namespace EduCore.EduOperation.Question
{
    public class UpdateQuestionOperation : BaseOperation
    {
        public UpdateQuestionOperation() : base("UPDATE_QUESTION")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
            CourseEditor = true;
        }
    }
}