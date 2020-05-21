using Model.Functions.CourseTerm;
using System.Collections.Generic;
using WebModel.CourseTermDto;

namespace EduFacade.CourseTermFacade.Convertor
{
    public interface ICourseTermConvertor
    {
        AddCourseTerm ConvertToBussinessEntity(AddCourseTermDto addCourseTermDto);
        IEnumerable<GetAllTermInCourseDto> ConvertToWebModel(IEnumerable<GetAllTermInCourse> getTermInCourses);
        GetCourseTermDetailDto ConvertToWebModel(GetCourseTermDetail getCourseTermDetail);
        UpdateCourseTerm ConvertToWebModel(UpdateCourseTermDto updateCourseTermDto);
    }
}
