using Model.Functions.CourseLessonItem;
using System;
using System.Collections.Generic;

namespace EduServices.CourseChapterService
{
    public interface ICourseLessonItemService : IBaseService
    {
        Guid AddCourseLessonItem(AddCourseLessonItem addCourseLessonItem);
        void DeleteCourseLessonItem(Guid courseLessonItemId);
        List<GetCourseLessonItems> GetCourseLessonItems(Guid courseLessonId);
        GetCourseLessonItemDetail GetCourseLessonItemDetail(Guid courseLessonItemId);
        void UpdateCourseLessonItem(UpdateCourseLessonItem updateCourseLessonItem);
    }
}
