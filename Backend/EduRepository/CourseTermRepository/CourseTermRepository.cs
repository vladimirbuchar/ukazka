using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Functions.CourseTerm;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EduRepository.CourseTermRepository
{
    public class CourseTermRepository : BaseRepository, ICourseTermRepository
    {
        public CourseTermRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {
        }


        public IEnumerable<GetAllTermInCourse> GetAllTermInCourse(Guid courseId)
        {
            return CallSqlFunction<GetAllTermInCourse>("GetTermInCourse", new List<SqlParameter>()
            {
                new SqlParameter("@courseId",courseId)
            }).ToList();
        }

        public GetCourseTermDetail GetCourseTermDetail(Guid courseTermId)
        {
            return CallSqlFunction<GetCourseTermDetail>("GetCourseTermDetail", new List<SqlParameter>()
            {
                new SqlParameter("@courseTermId",courseTermId)
            }).FirstOrDefault();
        }

        public Guid AddCourseTerm(AddCourseTerm addCourseTerm)
        {
            Guid outGuid = Guid.Empty;
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@TimeFromId", addCourseTerm.TimeFromId),
                new SqlParameter("@TimeToId", addCourseTerm.TimeToId),
                new SqlParameter("@ActiveFrom", addCourseTerm.ActiveFrom),
                new SqlParameter("@ActiveTo", addCourseTerm.ActiveTo),
                new SqlParameter("@RegistrationFrom", addCourseTerm.RegistrationFrom),
                new SqlParameter("@RegistrationTo", addCourseTerm.RegistrationTo),
                new SqlParameter("@Monday", addCourseTerm.Monday),
                new SqlParameter("@Tuesday", addCourseTerm.Tuesday),
                new SqlParameter("@Wednesday", addCourseTerm.Wednesday),
                new SqlParameter("@Thursday", addCourseTerm.Thursday),
                new SqlParameter("@Friday", addCourseTerm.Friday),
                new SqlParameter("@Saturday", addCourseTerm.Saturday),
                new SqlParameter("@Sunday", addCourseTerm.Sunday),
                new SqlParameter("@ClassRoomId", addCourseTerm.ClassRoomId),
                new SqlParameter("@CourseId", addCourseTerm.CourseId),
                new SqlParameter("@BasicInformationName", addCourseTerm.BasicInformationName),
                new SqlParameter("@BasicInformationDescription", addCourseTerm.BasicInformationDescription),
                new SqlParameter("@CoursePrice", addCourseTerm.CoursePrice),
                new SqlParameter("@CoursePriceSale", addCourseTerm.CoursePriceSale),
                new SqlParameter("@StudentCountMinimumStudent", addCourseTerm.StudentCountMinimumStudent),
                new SqlParameter("@StudentCountMaximumStudent", addCourseTerm.StudentCountMaximumStudent)
            };
            CallSqlProcedure("CreateCourseTerm", sqlParameters,true, ref outGuid);
            return outGuid;
        }

        public void UpdateCourseTerm(UpdateCourseTerm updateCourseTerm)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@TimeFromId", updateCourseTerm.TimeFromId),
                new SqlParameter("@TimeToId", updateCourseTerm.TimeToId),
                new SqlParameter("@ActiveFrom", updateCourseTerm.ActiveFrom),
                new SqlParameter("@ActiveTo", updateCourseTerm.ActiveTo),
                new SqlParameter("@RegistrationFrom", updateCourseTerm.RegistrationFrom),
                new SqlParameter("@RegistrationTo", updateCourseTerm.RegistrationTo),
                new SqlParameter("@Monday", updateCourseTerm.Monday),
                new SqlParameter("@Tuesday", updateCourseTerm.Tuesday),
                new SqlParameter("@Wednesday", updateCourseTerm.Wednesday),
                new SqlParameter("@Thursday", updateCourseTerm.Thursday),
                new SqlParameter("@Friday", updateCourseTerm.Friday),
                new SqlParameter("@Saturday", updateCourseTerm.Saturday),
                new SqlParameter("@Sunday", updateCourseTerm.Sunday),
                new SqlParameter("@ClassRoomId", updateCourseTerm.ClassRoomId),
                new SqlParameter("@Id", updateCourseTerm.Id),
                new SqlParameter("@BasicInformationName", updateCourseTerm.BasicInformationName),
                new SqlParameter("@BasicInformationDescription", updateCourseTerm.BasicInformationDescription),
                new SqlParameter("@CoursePrice", updateCourseTerm.CoursePrice),
                new SqlParameter("@CoursePriceSale", updateCourseTerm.CoursePriceSale),
                new SqlParameter("@StudentCountMinimumStudent", updateCourseTerm.StudentCountMinimumStudent),
                new SqlParameter("@StudentCountMaximumStudent", updateCourseTerm.StudentCountMaximumStudent)
            };
            CallSqlProcedure("UpdateCourseTerm", sqlParameters);
        }
    }
}
