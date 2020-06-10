using System;
using System.Collections.Generic;
using WebModel.CourseLesson;

namespace EduFacade.CourseChapterFacade
{
    public interface ICourseLessonFacade : IBaseFacade
    {
        void AddCourseLesson(AddCourseLessonDto addCourseLessonDto);
        List<GetAllLessonInCourseDto> GetAllLessonInCourse(Guid courseId);
        void DeleteCourseLesson(Guid courseLessonId);
        void UpdateCourseLesson(UpdateCourseLessonDto updateCourseLessonDto);
        GetCourseLessonDetailDto GetCourseLessonDetail(Guid courseLessonId);
        void UpdatePositionCourseLesson(UpdatePositionCourseLessonDto updatePositionCourseLesson);
    }
}
