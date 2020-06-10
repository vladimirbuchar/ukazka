using EduRepository.CourseChapterRepository;
using Model.Functions.CourseLesson;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;

namespace EduServices.CourseChapterService
{

    public class CourseLessonService : ICourseLessonService
    {
        private readonly ICourseLessonRepository _courseLessonRepository;
        public CourseLessonService(ICourseLessonRepository courseLessonRepository)
        {
            _courseLessonRepository = courseLessonRepository;
        }
        public void AddCourseLesson(AddCourseLesson addCourseLesson)
        {
            _courseLessonRepository.AddCourseLesson(addCourseLesson);
        }

        public void UpdatePositionCourseLesson(UpdatePositionCourseLesson updatePositionCourseLesson)
        {
            _courseLessonRepository.UpdatePositionCourseLesson(updatePositionCourseLesson);
        }

        public void DeleteCourseLesson(Guid courseLessonId)
        {
            _courseLessonRepository.DeleteEntity<CourseLesson>(courseLessonId);
        }

        public List<GetAllLessonInCourse> GetAllLessonInCourse(Guid courseId)
        {
            return _courseLessonRepository.GetAllLessonInCourse(courseId);
        }

        public GetCourseLessonDetail GetCourseLessonDetail(Guid courseLessonId)
        {
            return _courseLessonRepository.GetCourseLessonDetail(courseLessonId);
        }

        public void UpdateCourseLesson(UpdateCourseLesson updateCourseLesson)
        {
            _courseLessonRepository.UpdateCourseLesson(updateCourseLesson);
        }
    }
}
