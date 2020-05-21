using Model.Functions.CourseStudent;
using System.Collections.Generic;
using WebModel.StudentDto;

namespace EduFacade.CourseStudentFacade.Convertor
{
    public class CourseStudentConvertor : ICourseStudentConvertor
    {
        public AddStudentToCourseTerm ConvertToBussinessEntity(AddStudentToCourseTermDto addStudentToCourseDto)
        {
            return new AddStudentToCourseTerm()
            {
                CourseTermId = addStudentToCourseDto.CourseTermId,
                UserId = addStudentToCourseDto.UserId
            };
        }

        public List<GetAllStudentInCourseTermDto> ConvertToWebModel(List<GetAllStudentInCourseTerm> getStudentsInTerms)
        {
            List<GetAllStudentInCourseTermDto> data = new List<GetAllStudentInCourseTermDto>();
            foreach (GetAllStudentInCourseTerm item in getStudentsInTerms)
            {
                data.Add(new GetAllStudentInCourseTermDto()
                {
                    FirstName = item.FirstName,
                    Id = item.Id,
                    LastName = item.LastName,
                    SecondName = item.SecondName,
                    StudentId = item.StudentId
                });
            }
            return data;
        }
    }
}
