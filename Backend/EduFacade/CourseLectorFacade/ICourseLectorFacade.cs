using System;
using System.Collections.Generic;
using WebModel.CourseLectorDto;

namespace EduFacade.CourseLectorFacade
{
    public interface ICourseLectorFacade : IBaseFacade
    {
        void AddCourseLector(AddCourseLectorDto addCourseLectorDto);
        void DeleteCourseTermLector(Guid oid);
        List<GetAllLectorCourseTermDto> GetAllLectorCourseTerm(Guid courseTermId);
    }
}
