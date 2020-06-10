using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Functions.CourseLessonItem;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EduRepository.CourseChapterRepository
{
    public class CourseLessonItemRepository : BaseRepository, ICourseLessonItemRepository
    {
        public CourseLessonItemRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {

        }

        public Guid AddCourseLessonItem(AddCourseLessonItem addCourseLessonItem)
        {
            Guid outGuid = Guid.Empty;
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@CourseLessonId", addCourseLessonItem.CourseLessonId),
                new SqlParameter("@BasicInformationName", addCourseLessonItem.Name),
                new SqlParameter("@BasicInformationDescription", addCourseLessonItem.Description),
                new SqlParameter("@Html", addCourseLessonItem.Html),
                new SqlParameter("@TemplateId", addCourseLessonItem.TemplateId),
            };
            CallSqlProcedure("AddCourseLessonItem", sqlParameters,true, ref outGuid);
            return outGuid;
                }

        public void UpdateCourseLessonItem(UpdateCourseLessonItem updateCourseLessonItem)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@CourseLessonItemId", updateCourseLessonItem.CourseLessonItemId),
                new SqlParameter("@BasicInformationName", updateCourseLessonItem.Name),
                new SqlParameter("@BasicInformationDescription", updateCourseLessonItem.Description),
                new SqlParameter("@Html", updateCourseLessonItem.Html)
            };
            CallSqlProcedure("UpdateCourseLessonItem", sqlParameters);
        }

        public List<GetCourseLessonItems> GetCourseLessonItems(Guid courseLessonId)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@CourseLessonId", courseLessonId)
            };
            return CallSqlFunction<GetCourseLessonItems>("GetCourseLessonItems", sqlParameters);
        }

        public GetCourseLessonItemDetail GetCourseLessonItemDetail(Guid courseLessonItemId)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@CourseLessonItemId", courseLessonItemId)
            };
            return CallSqlFunction<GetCourseLessonItemDetail>("GetCourseLessonItemDetail", sqlParameters).FirstOrDefault();
        }


    }
}
