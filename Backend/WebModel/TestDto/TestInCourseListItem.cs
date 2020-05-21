using WebModel.Shared;

namespace WebModel.TestDto
{
    public class TestInCourseListItem : BaseDto
    {
        public int Id { get; internal set; }
        public int CourseId { get; internal set; }
        public string Name { get; internal set; }
        public bool RandomGenerateQuestion { get; internal set; }
        public int QuestionCountInTest { get; internal set; }
        public int TimeLimit { get; internal set; }
        public int DesiredSuccess { get; internal set; }
    }
}
