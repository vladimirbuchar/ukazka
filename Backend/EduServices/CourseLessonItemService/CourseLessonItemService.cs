using EduRepository.CourseChapterRepository;
using Model.Functions.CourseLessonItem;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;

namespace EduServices.CourseChapterService
{

    public class CourseLessonItemService : ICourseLessonItemService
    {
        private readonly ICourseLessonItemRepository _courseLessonItemRepository;
        public CourseLessonItemService(ICourseLessonItemRepository courseLessonItemRepository)
        {
            _courseLessonItemRepository = courseLessonItemRepository;
        }
        public void AddCourseLessonItem(AddCourseLessonItem addCourseLessonItem)
        {
            _courseLessonItemRepository.AddCourseLessonItem(addCourseLessonItem);
        }

        public void DeleteCourseLessonItem(Guid courseLessonItemId)
        {
            _courseLessonItemRepository.DeleteEntity<CourseItem>(courseLessonItemId);
        }

        public List<GetCourseLessonItems> GetCourseLessonItems(Guid courseLessonId)
        {
            return _courseLessonItemRepository.GetCourseLessonItems(courseLessonId);
        }

        public GetCourseLessonItemDetail GetCourseLessonItemDetail(Guid courseLessonItemId)
        {
            return _courseLessonItemRepository.GetCourseLessonItemDetail(courseLessonItemId);
        }

        public void UpdateCourseLessonItem(UpdateCourseLessonItem updateCourseLessonItem)
        {
            _courseLessonItemRepository.UpdateCourseLessonItem(updateCourseLessonItem);
        }
    }
}
