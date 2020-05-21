using Core.DataTypes;
using System;
using System.Collections.Generic;
using WebModel.StudentDto;

namespace EduFacade.CourseStudentFacade
{
    public interface ICourseStudentFacade : IBaseFacade
    {
        Result AddStudentToCourseTerm(AddStudentToCourseTermDto addStudentToCourseTermDto);
        List<GetAllStudentInCourseTermDto> GetAllStudentInCourseTerm(Guid courseTermId);
        void DeleteStudentFromCourseTerm(Guid courseStudentTermId);
    }
}
