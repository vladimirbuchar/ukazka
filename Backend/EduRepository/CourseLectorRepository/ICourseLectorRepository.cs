using Model.Functions.CourseLector;
using System;
using System.Collections.Generic;

namespace EduRepository.CourseLectorRepository
{
    public interface ICourseLectorRepository : IBaseRepository
    {
        List<CourseTermLector> GetAllLectorCourseTerm(Guid courseTermId);
        void AddCourseLector(AddCourseLector addCourseLector);


    }
}
