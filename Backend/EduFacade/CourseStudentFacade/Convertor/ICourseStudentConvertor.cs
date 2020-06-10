using Model.Functions.CourseStudent;
using System.Collections.Generic;
using WebModel.StudentDto;

namespace EduFacade.CourseStudentFacade.Convertor
{
    public interface ICourseStudentConvertor
    {
        List<GetAllStudentInCourseTermDto> ConvertToWebModel(List<GetAllStudentInCourseTerm> getStudentsInTerms);
    }
}
