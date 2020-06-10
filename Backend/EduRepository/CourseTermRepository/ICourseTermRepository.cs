using Model.Functions.CourseTerm;
using System;
using System.Collections.Generic;

namespace EduRepository.CourseTermRepository
{
    public interface ICourseTermRepository : IBaseRepository
    {
        IEnumerable<GetAllTermInCourse> GetAllTermInCourse(Guid courseId);
        GetCourseTermDetail GetCourseTermDetail(Guid courseTermId);
        Guid AddCourseTerm(AddCourseTerm addCourseTerm);
        void UpdateCourseTerm(UpdateCourseTerm updateCourseTerm);
    }
}
