using Model.Tables.Edu;
using System;

namespace EduRepository.StudentTestSummaryRepository
{
    public interface IStudentTestSummaryRepository : IBaseRepository
    {
        StudentTestSummary GetStudentTestSummary(Guid userTestSummaryId);

        StudentTestSummary StartTest(StudentTestSummary studentTestSummary);
    }
}
