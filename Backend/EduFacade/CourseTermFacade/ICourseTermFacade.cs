using Core.DataTypes;
using System;
using System.Collections.Generic;
using WebModel.CourseTermDto;

namespace EduFacade.CourseTermFacade
{
    public interface ICourseTermFacade : IBaseFacade
    {
        Result AddCourseTerm(AddCourseTermDto addCourseTermDto);
        IEnumerable<GetAllTermInCourseDto> GetAllTermInCourse(Guid courseId);
        GetCourseTermDetailDto GetCourseTermDetail(Guid courseTermId);
        Result UpdateCourseTerm(UpdateCourseTermDto updateCourseTermDto);
        void DeleteCourseTerm(Guid courseTermId);
    }
}
