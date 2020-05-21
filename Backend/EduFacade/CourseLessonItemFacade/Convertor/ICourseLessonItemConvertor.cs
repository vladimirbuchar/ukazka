using Model.Functions.CourseLessonItem;
using System.Collections.Generic;
using WebModel.CourseLessonItemDto;

namespace EduFacade.CourseLessonItemFacade.Convertor
{
    public interface ICourseLessonItemConvertor
    {
        AddCourseLessonItem ConvertToBussinessEntity(AddCourseLessonItemDto addCourseLessonItemDto);
        List<GetCourseLessonItemsDto> ConvertToWebModel(List<GetCourseLessonItems> getCourseLessonItems);
        GetCourseLessonItemDetailDto ConvertToWebModel(GetCourseLessonItemDetail getCourseLessonItemDetail);
        UpdateCourseLessonItem ConvertToBussinessEntity(UpdateCourseLessonItemDto updateCourseLessonItemDto);
    }
}
