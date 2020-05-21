using Core.DataTypes;
using System;
using System.Collections.Generic;
using WebModel.CourseDto;

namespace EduFacade.CourseFacade
{
    public interface ICourseFacade : IBaseFacade
    {
        IEnumerable<GetCourseOfferDto> GetCourseOffer(CourseFilterDto courseFilterDto);
        Result AddCourse(AddCourseDto addCourseDto);
        List<GetAllCourseInOrganizationDto> GetAllCourseInOrganization(Guid organizationId);
        GetCourseDetailDto GetCourseDetail(Guid courseId);
        Result UpdateCourse(UpdateCourseDto updateCourseDto);
        void DeleteCourse(Guid courseId);
    }
}
