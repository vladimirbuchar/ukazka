using Model.Functions.CourseTerm;
using System.Collections.Generic;
using WebModel.CourseTermDto;

namespace EduFacade.CourseTermFacade.Convertor
{
    public class CourseTermConvertor : ICourseTermConvertor
    {
        public AddCourseTerm ConvertToBussinessEntity(AddCourseTermDto addCourseTermDto)
        {
            return new AddCourseTerm()
            {
                ActiveFrom = addCourseTermDto.ActiveFrom,
                ActiveTo = addCourseTermDto.ActiveTo,
                ClassRoomId = addCourseTermDto.ClassRoomId,
                CourseId = addCourseTermDto.CourseId,
                BasicInformationDescription = addCourseTermDto.Description,
                Friday = addCourseTermDto.Friday,
                StudentCountMaximumStudent = addCourseTermDto.MaximumStudents,
                StudentCountMinimumStudent = addCourseTermDto.MinimumStudents,
                Monday = addCourseTermDto.Monday,
                BasicInformationName = addCourseTermDto.Name,
                CoursePrice = addCourseTermDto.Price.Price,
                RegistrationFrom = addCourseTermDto.RegistrationFrom,
                RegistrationTo = addCourseTermDto.RegistrationTo,
                CoursePriceSale = addCourseTermDto.Price.Sale,
                Saturday = addCourseTermDto.Saturday,
                Sunday = addCourseTermDto.Sunday,
                Thursday = addCourseTermDto.Thursday,
                TimeFromId = addCourseTermDto.TimeFromId,
                TimeToId = addCourseTermDto.TimeToId,
                Tuesday = addCourseTermDto.Tuesday,
                Wednesday = addCourseTermDto.Wednesday
            };
        }

        public IEnumerable<GetAllTermInCourseDto> ConvertToWebModel(IEnumerable<GetAllTermInCourse> getTermInCourses)
        {
            List<GetAllTermInCourseDto> data = new List<GetAllTermInCourseDto>();
            foreach (GetAllTermInCourse item in getTermInCourses)
            {
                data.Add(new GetAllTermInCourseDto()
                {
                    ActiveFrom = item.ActiveFrom,
                    ActiveTo = item.ActiveTo,
                    Description = item.Description,
                    Name = item.Name,
                    ClassRoomId = item.ClassRoomId,
                    CourseId = item.CourseId,
                    CoursePrice = new WebModel.Shared.CoursePriceDto()
                    {
                        Price = item.Price,
                        Sale = item.Sale
                    },
                    Friday = item.Friday,
                    Id = item.Id,
                    Monday = item.Monday,
                    RegistrationFrom = item.RegistrationFrom,
                    RegistrationTo = item.RegistrationTo,
                    Saturday = item.Saturday,
                    MaximumStudent = item.MaximumStudent,
                    MinimumStudent = item.MinimumStudent,
                    Sunday = item.Sunday,
                    Thursday = item.Thursday,
                    TimeFromId = item.TimeFromId,
                    TimeToId = item.TimeToId,
                    Tuesday = item.Tuesday,
                    Wednesday = item.Wednesday
                });
            }
            return data;
        }

        public GetCourseTermDetailDto ConvertToWebModel(GetCourseTermDetail getCourseTermDetail)
        {
            return new GetCourseTermDetailDto()
            {
                ActiveFrom = getCourseTermDetail.ActiveFrom,
                Id = getCourseTermDetail.Id,
                Wednesday = getCourseTermDetail.Wednesday,
                ActiveTo = getCourseTermDetail.ActiveTo,
                ClassRoomId = getCourseTermDetail.ClassRoomId,
                BranchId = getCourseTermDetail.BranchId,
                CoursePrice = new WebModel.Shared.CoursePriceDto()
                {
                    Price = getCourseTermDetail.Price,
                    Sale = getCourseTermDetail.Sale
                },
                Friday = getCourseTermDetail.Friday,
                MaximumStudent = getCourseTermDetail.MaximumStudent,
                MinimumStudent = getCourseTermDetail.MinimumStudent,
                Monday = getCourseTermDetail.Monday,
                RegistrationFrom = getCourseTermDetail.RegistrationFrom,
                RegistrationTo = getCourseTermDetail.RegistrationTo,
                Saturday = getCourseTermDetail.Saturday,
                Sunday = getCourseTermDetail.Sunday,
                Thursday = getCourseTermDetail.Thursday,
                TimeFromId = getCourseTermDetail.TimeFromId,
                TimeToId = getCourseTermDetail.TimeToId,
                Tuesday = getCourseTermDetail.Tuesday,
                
                
            };
        }

        public UpdateCourseTerm ConvertToWebModel(UpdateCourseTermDto updateCourseTermDto)
        {
            return new UpdateCourseTerm()
            {
                ActiveFrom = updateCourseTermDto.ActiveFrom,
                ActiveTo = updateCourseTermDto.ActiveTo,
                BasicInformationDescription = updateCourseTermDto.Description,
                BasicInformationName = updateCourseTermDto.Name,
                ClassRoomId = updateCourseTermDto.ClassRoomId,
                CoursePrice = updateCourseTermDto.Price.Price,
                CoursePriceSale = updateCourseTermDto.Price.Sale,
                Friday = updateCourseTermDto.Friday,
                Id = updateCourseTermDto.Id,
                Monday = updateCourseTermDto.Monday,
                RegistrationFrom = updateCourseTermDto.RegistrationFrom,
                RegistrationTo = updateCourseTermDto.RegistrationTo,
                Saturday = updateCourseTermDto.Saturday,
                StudentCountMaximumStudent = updateCourseTermDto.MaximumStudents,
                StudentCountMinimumStudent = updateCourseTermDto.MinimumStudents,
                Sunday = updateCourseTermDto.Sunday,
                Thursday = updateCourseTermDto.Thursday,
                TimeFromId = updateCourseTermDto.TimeFromId,
                TimeToId = updateCourseTermDto.TimeToId,
                Tuesday = updateCourseTermDto.Tuesday,
                Wednesday = updateCourseTermDto.Wednesday
            };
        }
    }
}
