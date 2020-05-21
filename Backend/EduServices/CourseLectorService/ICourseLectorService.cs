using Model.Functions.CourseLector;
using System;
using System.Collections.Generic;

namespace EduServices.CourseLectorService
{
    public interface ICourseLectorService : IBaseService
    {
        void AddCourseLector(AddCourseLector addCourseLector);
        void DeleteCourseTermLector(Guid courseLectorTemId);
        List<CourseTermLector> GetAllLectorCourseTerm(Guid courseTermId);


    }
}
