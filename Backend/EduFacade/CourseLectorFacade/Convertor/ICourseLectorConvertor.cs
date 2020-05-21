using Model.Functions.CourseLector;
using System.Collections.Generic;
using WebModel.CourseLectorDto;

namespace EduFacade.CourseLectorFacade.Convertor
{
    public interface ICourseLectorConvertor
    {
        AddCourseLector ConvertToBussinessEntity(AddCourseLectorDto addCourseLectorDto);
        List<GetAllLectorCourseTermDto> ConvertToWebModel(List<CourseTermLector> courseTermLectors);
    }
}
