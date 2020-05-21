using Model.Functions.CourseLessonItem;
using System;
using System.Collections.Generic;

namespace EduRepository.CourseChapterRepository
{
    public interface ICourseLessonItemRepository : IBaseRepository
    {
        void AddCourseLessonItem(AddCourseLessonItem addCourseLessonItem);
        List<GetCourseLessonItems> GetCourseLessonItems(Guid courseId);
        GetCourseLessonItemDetail GetCourseLessonItemDetail(Guid courseLessonItemId);
        void UpdateCourseLessonItem(UpdateCourseLessonItem updateCourseLessonItem);
    }
}
