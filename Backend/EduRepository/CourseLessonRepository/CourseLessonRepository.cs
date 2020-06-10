using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Functions.CourseLesson;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EduRepository.CourseChapterRepository
{
    public class CourseLessonRepository : BaseRepository, ICourseLessonRepository
    {
        public CourseLessonRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {

        }

        public void AddCourseLesson(AddCourseLesson addCourseLesson)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@CourseId", addCourseLesson.CourseId),
                new SqlParameter("@BasicInformationName", addCourseLesson.Name),
                new SqlParameter("@BasicInformationDescription", addCourseLesson.Description)
            };
            CallSqlProcedure("AddCourseLesson", sqlParameters);
        }

        public void UpdateCourseLesson(UpdateCourseLesson updateCourseLesson)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@CourseLessonId", updateCourseLesson.Id),
                new SqlParameter("@BasicInformationName", updateCourseLesson.Name),
                new SqlParameter("@BasicInformationDescription", updateCourseLesson.Description)
            };
            CallSqlProcedure("UpdateCourseLesson", sqlParameters);
        }

        public List<GetAllLessonInCourse> GetAllLessonInCourse(Guid courseId)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@courseId", courseId)
            };
            return CallSqlFunction<GetAllLessonInCourse>("GetAllLessonInCourse", sqlParameters).OrderBy(x => x.Position).ToList() ;
        }

        public GetCourseLessonDetail GetCourseLessonDetail(Guid courseLessonId)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@courseLessonId", courseLessonId)
            };
            return CallSqlFunction<GetCourseLessonDetail>("GetCourseLessonDetail", sqlParameters).FirstOrDefault();
        }

        public void UpdatePositionCourseLesson(UpdatePositionCourseLesson updatePositionCourseLesson)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@CourseLessonId", updatePositionCourseLesson.Id),
                new SqlParameter("@NewPosition", updatePositionCourseLesson.NewPosition)
            };
            CallSqlProcedure("UpdatePositionCourseLesson", sqlParameters);
        }
    }
}
