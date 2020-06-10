using EduFacade.CourseLessonItemFacade.Convertor;
using EduServices.CourseChapterService;
using Model.Functions.CourseLessonItem;
using System;
using System.Collections.Generic;
using WebModel.CourseLessonItemDto;

namespace EduFacade.CourseLessonItemFacade
{
    public class CourseLessonItemFacade : BaseFacade, ICourseLessonItemFacade
    {
        private readonly ICourseLessonItemService _courseLessonItemService;
        private readonly ICourseLessonItemConvertor _courseLessonItemConvertor;
        public CourseLessonItemFacade(ICourseLessonItemService courseLessonItemService, ICourseLessonItemConvertor courseLessonItemConvertor)
        {
            _courseLessonItemService = courseLessonItemService;
            _courseLessonItemConvertor = courseLessonItemConvertor;
        }

        public Guid AddCourseLessonItem(AddCourseLessonItemDto addCourseLessonItemDto)
        {
            AddCourseLessonItem addCourseLessonItem = _courseLessonItemConvertor.ConvertToBussinessEntity(addCourseLessonItemDto);
            return _courseLessonItemService.AddCourseLessonItem(addCourseLessonItem);
        }
        public void DeleteCourseLessonItem(Guid courseLessonItemId)
        {
            _courseLessonItemService.DeleteCourseLessonItem(courseLessonItemId);
        }

        public List<GetCourseLessonItemsDto> GetCourseLessonItems(Guid courseLessonId)
        {
            return _courseLessonItemConvertor.ConvertToWebModel(_courseLessonItemService.GetCourseLessonItems(courseLessonId));
        }
        public GetCourseLessonItemDetailDto GetCourseLessonItemDetail(Guid courseLessonItemId)
        {
            return _courseLessonItemConvertor.ConvertToWebModel(_courseLessonItemService.GetCourseLessonItemDetail(courseLessonItemId));
        }

        public void UpdateCourseLessonItem(UpdateCourseLessonItemDto updateCourseLessonItemDto)
        {
            UpdateCourseLessonItem updateCourseLessonItem = _courseLessonItemConvertor.ConvertToBussinessEntity(updateCourseLessonItemDto);
            _courseLessonItemService.UpdateCourseLessonItem(updateCourseLessonItem);
        }
    }
}
