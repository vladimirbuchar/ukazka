using WebModel.Shared;

namespace WebModel.TestDto
{
    public class CreateTestRequest : BaseDto
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public bool RandomGenerateQuestion { get; set; }
        public int QuestionCountInTest { get; set; }
        public int TimeLimit { get; set; }
        public int DesiredSuccess { get; set; }
    }
}
