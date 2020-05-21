using System;
using WebModel.Shared;

namespace WebModel.StudentDto
{
    public class AddStudentToCourseTermDto : BaseDto, IBaseDtoWithUserAccessToken
    {
        public Guid UserId { get; set; }
        public Guid CourseTermId { get; set; }
        public string UserAccessToken { get; set; }
    }
}
