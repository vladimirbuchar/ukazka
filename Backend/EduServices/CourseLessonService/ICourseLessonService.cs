using Model.Functions.CourseLesson;
using System;
using System.Collections.Generic;

namespace EduServices.CourseChapterService
{
    public interface ICourseLessonService : IBaseService
    {
        void AddCourseLesson(AddCourseLesson addCourseLesson);
        void DeleteCourseLesson(Guid courseLessonId);
        List<GetAllLessonInCourse> GetAllLessonInCourse(Guid courseId);
        GetCourseLessonDetail GetCourseLessonDetail(Guid courseLessonId);
        void UpdateCourseLesson(UpdateCourseLesson updateCourseLesson);
        void UpdatePositionCourseLesson(UpdatePositionCourseLesson updatePositionCourseLesson);
    }
}
