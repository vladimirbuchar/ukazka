using EduCore.DataTypes;

namespace EduCore.EduOperation.Question
{
    public class DeleteQuestionOperation : BaseOperation
    {
        public DeleteQuestionOperation() : base("DELETE_QUESTION")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
            CourseEditor = true;
        }
    }
}