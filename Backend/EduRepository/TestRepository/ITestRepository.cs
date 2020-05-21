using Model.Tables.Edu;
using System;
using System.Collections.Generic;

namespace EduRepository.TestRepository
{
    public interface ITestRepository : IBaseRepository
    {
        IEnumerable<CourseTest> GetAllTestsInCourse(Guid courseId);
    }
}
