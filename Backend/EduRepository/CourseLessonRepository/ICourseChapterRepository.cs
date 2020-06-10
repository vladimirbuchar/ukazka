using Model.Functions.CourseLesson;
using System;
using System.Collections.Generic;

namespace EduRepository.CourseChapterRepository
{
    public interface ICourseLessonRepository : IBaseRepository
    {
        void AddCourseLesson(AddCourseLesson addCourseLesson);
        List<GetAllLessonInCourse> GetAllLessonInCourse(Guid courseId);
        GetCourseLessonDetail GetCourseLessonDetail(Guid courseLessonId);
        void UpdateCourseLesson(UpdateCourseLesson updateCourseLesson);
        void UpdatePositionCourseLesson(UpdatePositionCourseLesson updatePositionCourseLesson);
    }
}
