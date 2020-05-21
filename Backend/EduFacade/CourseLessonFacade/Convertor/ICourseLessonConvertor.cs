using Model.Functions.CourseLesson;
using System.Collections.Generic;
using WebModel.CourseLesson;

namespace EduFacade.CourseLessonFacade.Convertor
{
    public interface ICourseLessonConvertor
    {
        AddCourseLesson ConvertToBussinessEntity(AddCourseLessonDto addCourseLessonDto);
        List<GetAllLessonInCourseDto> ConvertToWebModel(List<GetAllLessonInCourse> getAllLessonInCourses);
        GetCourseLessonDetailDto ConvertToWebModel(GetCourseLessonDetail getCourseLessonDetail);
        UpdateCourseLesson ConvertToWebModel(UpdateCourseLessonDto updateCourseLessonDto);
    }
}
