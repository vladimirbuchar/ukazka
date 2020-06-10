using System;
using System.Collections.Generic;
using WebModel.CourseLessonItemDto;

namespace EduFacade.CourseLessonItemFacade
{
    public interface ICourseLessonItemFacade : IBaseFacade
    {
        Guid AddCourseLessonItem(AddCourseLessonItemDto addCourseLessonItemDto);
        List<GetCourseLessonItemsDto> GetCourseLessonItems(Guid courseLessonId);
        void DeleteCourseLessonItem(Guid courseLessonItemId);
        void UpdateCourseLessonItem(UpdateCourseLessonItemDto updateCourseLessonItemDto);
        GetCourseLessonItemDetailDto GetCourseLessonItemDetail(Guid courseLessonItemId);
    }
}
