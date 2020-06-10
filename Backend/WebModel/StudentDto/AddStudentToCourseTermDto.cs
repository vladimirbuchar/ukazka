using System;
using System.Collections.Generic;
using WebModel.Shared;

namespace WebModel.StudentDto
{
    public class AddStudentToCourseTermDto : BaseDto, IBaseDtoWithUserAccessToken
    {
        public List<string> UserEmail { get; set; }
        public Guid CourseTermId { get; set; }
        public string UserAccessToken { get; set; }
    }
}
