using System.Collections.Generic;
using WebModel.Shared;

namespace WebModel.TestDto
{
    public class GenerateTestResponse : BaseDto
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public string Name { get; set; }
        public List<GenerateTestQuestion> Questions { get; set; }
        public int TimeLimit { get; set; }
    }
}
