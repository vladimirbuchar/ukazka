using Model.Functions.Course;
using System.Collections.Generic;
using WebModel.CourseDto;

namespace EduFacade.CourseFacade.Convertor
{
    public class CourseConvertor : ICourseConvertor
    {
        public AddCourse ConvertToBussinessEntity(AddCourseDto addCourseDto)
        {
            return new AddCourse()
            {
                BasicInformationDescription = addCourseDto.Description,
                BasicInformationName = addCourseDto.Name,
                CoursePrice = addCourseDto.Price.Price,
                CoursePriceSale = addCourseDto.Price.Sale,
                CourseStatusId = addCourseDto.CourseStatusId,
                CourseTypeId = addCourseDto.CourseTypeId,
                OrganizationId = addCourseDto.OrganizationId,
                IsPrivateCourse = addCourseDto.IsPrivateCourse,
                StudentCountMaximumStudent = addCourseDto.DefaultMaximumStudents,
                StudentCountMinimumStudent = addCourseDto.DefaultMinimumStudents
            };
        }

        public UpdateCourse ConvertToBussinessEntity(UpdateCourseDto updateCourseDto)
        {
            return new UpdateCourse()
            {
                BasicInformationDescription = updateCourseDto.Description,
                BasicInformationName = updateCourseDto.Name,
                CourseId = updateCourseDto.Id,
                CoursePrice = updateCourseDto.Price.Price,
                CoursePriceSale = updateCourseDto.Price.Sale,
                CourseStatusId = updateCourseDto.CourseStatusId,
                CourseTypeId = updateCourseDto.CourseTypeId,
                IsPrivateCourse = updateCourseDto.IsPrivateCourse,
                StudentCountMaximumStudent = updateCourseDto.DefaultMaximumStudents,
                StudentCountMinimumStudent = updateCourseDto.DefaultMinimumStudents
            };
        }

        public List<GetAllCourseInOrganizationDto> ConvertToWebModel(List<GetAllCourseInOrganization> getAllCourseInOrganizations)
        {
            List<GetAllCourseInOrganizationDto> data = new List<GetAllCourseInOrganizationDto>();
            foreach (GetAllCourseInOrganization item in getAllCourseInOrganizations)
            {
                data.Add(new GetAllCourseInOrganizationDto()
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
            return data;
        }

        public GetCourseDetailDto ConvertToWebModel(GetCourseDetail getCourseDetail)
        {
            return new GetCourseDetailDto()
            {
                CourseStatusId = getCourseDetail.CourseStatusId,
                Description = getCourseDetail.Description,
                Name = getCourseDetail.Name,
                CourseTypeId = getCourseDetail.CourseTypeId,
                FileName = "",
                Id = getCourseDetail.Id,
                IsPrivateCourse = getCourseDetail.IsPrivateCourse,
                CoursePrice = new WebModel.Shared.CoursePriceDto()
                {
                    Price = getCourseDetail.Price,
                    Sale = getCourseDetail.Sale
                }
            };
        }
    }
}
