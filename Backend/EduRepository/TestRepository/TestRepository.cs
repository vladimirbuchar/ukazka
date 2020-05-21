using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;

namespace EduRepository.TestRepository
{
    public class TestRepository : BaseRepository, ITestRepository
    {
        public TestRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {
        }


        public IEnumerable<CourseTest> GetAllTestsInCourse(Guid courseId)
        {
            return null;/*
            return (from t in dbContext.CourseTest
                    where t.CourseId == courseId && t.IsDeleted == false
                    select t);*/
        }
    }
}
