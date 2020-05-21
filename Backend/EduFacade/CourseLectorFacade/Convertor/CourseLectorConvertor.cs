using Model.Functions.CourseLector;
using System.Collections.Generic;
using WebModel.CourseLectorDto;

namespace EduFacade.CourseLectorFacade.Convertor
{
    public class CourseLectorConvertor : ICourseLectorConvertor
    {
        public AddCourseLector ConvertToBussinessEntity(AddCourseLectorDto addCourseLectorDto)
        {
            return new AddCourseLector()
            {
                CourseLector = addCourseLectorDto.CourseLector,
                CourseTerm = addCourseLectorDto.CourseTerm
            };
        }

        public List<GetAllLectorCourseTermDto> ConvertToWebModel(List<CourseTermLector> courseTermLectors)
        {
            List<GetAllLectorCourseTermDto> data = new List<GetAllLectorCourseTermDto>();
            foreach (CourseTermLector item in courseTermLectors)
            {
                data.Add(new GetAllLectorCourseTermDto()
                {
                    FirstName = item.FirstName,
                    Id = item.Id,
                    LastName = item.LastName,
                    SecondName = item.SecondName
                });
            }
            return data;
        }
    }
}
