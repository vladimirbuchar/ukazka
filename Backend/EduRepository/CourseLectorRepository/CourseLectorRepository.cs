using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Functions.CourseLector;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EduRepository.CourseLectorRepository
{
    public class CourseLectorRepository : BaseRepository, ICourseLectorRepository
    {
        public CourseLectorRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {

        }

        public void AddCourseLector(AddCourseLector addCourseLector)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@CourseTermId", addCourseLector.CourseTerm),
                new SqlParameter("@UserInOrganizationId", addCourseLector.CourseLector)
            };
            CallSqlProcedure("AddCourseLector", sqlParameters);
        }

        public List<CourseTermLector> GetAllLectorCourseTerm(Guid courseTermId)
        {
            return CallSqlFunction<CourseTermLector>("GetAllCourseTermLector", new List<SqlParameter>()
            {
                new SqlParameter("@courseTermId",courseTermId)
            }).ToList();
        }
    }
}
