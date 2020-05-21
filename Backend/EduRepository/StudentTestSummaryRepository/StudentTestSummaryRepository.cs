using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Tables.Edu;
using System;
namespace EduRepository.StudentTestSummaryRepository
{
    public class StudentTestSummaryRepository : BaseRepository, IStudentTestSummaryRepository
    {
        public StudentTestSummaryRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {
        }

        public StudentTestSummary GetStudentTestSummary(Guid userTestSummaryId)
        {
            return null;
            /*return (from uts in dbContext.StudentTestSummary
                    where uts.Id == userTestSummaryId && uts.IsDeleted == false
                    select uts).FirstOrDefault();*/
        }


        public StudentTestSummary StartTest(StudentTestSummary studentTestSummary)
        {
            return null;
            /*dbContext.StudentTestSummary.Add(studentTestSummary);
            dbContext.SaveChanges();
            return studentTestSummary;*/
        }
    }
}
