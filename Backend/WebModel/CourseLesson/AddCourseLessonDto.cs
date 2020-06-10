using System;
using WebModel.Shared;

namespace WebModel.CourseLesson
{
    public struct CourseLessonType
    {
        public static string COURSE_ITEM = "COURSE_ITEM";
        public static string COURSE_TEST = "COURSE_TEST";
    }
    public class AddCourseLessonDto : BaseDto, IBaseDtoWithUserAccessToken, IBasicInformationDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CourseId { get; set; }
        public string UserAccessToken { get; set; }
        public string Type { get; set; } = CourseLessonType.COURSE_ITEM;
    }
}
