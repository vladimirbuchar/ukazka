using Model.Functions.CourseStudent;
using System.Collections.Generic;
using WebModel.StudentDto;

namespace EduFacade.CourseStudentFacade.Convertor
{
    public interface ICourseStudentConvertor
    {
        AddStudentToCourseTerm ConvertToBussinessEntity(AddStudentToCourseTermDto addStudentToCourseDto);
        List<GetAllStudentInCourseTermDto> ConvertToWebModel(List<GetAllStudentInCourseTerm> getStudentsInTerms);
    }
}
