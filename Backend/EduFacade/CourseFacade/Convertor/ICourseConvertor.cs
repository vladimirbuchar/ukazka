using Model.Functions.Course;
using System.Collections.Generic;
using WebModel.CourseDto;

namespace EduFacade.CourseFacade.Convertor
{
    public interface ICourseConvertor
    {
        AddCourse ConvertToBussinessEntity(AddCourseDto addCourseDto);
        List<GetAllCourseInOrganizationDto> ConvertToWebModel(List<GetAllCourseInOrganization> getAllCourseInOrganizations);
        GetCourseDetailDto ConvertToWebModel(GetCourseDetail getCourseDetail);
        UpdateCourse ConvertToBussinessEntity(UpdateCourseDto updateCourseDto);
    }
}
