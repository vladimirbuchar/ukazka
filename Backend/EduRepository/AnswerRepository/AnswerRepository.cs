using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Functions.Answer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EduRepository.AnswerRepository
{
    public class AnswerRepository : BaseRepository, IAnswerRepository
    {
        public AnswerRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {

        }

        public GetAnswerDetail GetAnswerDetail(Guid answerId)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@answerId", answerId)
            };
            return CallSqlFunction<GetAnswerDetail>("GetAnswerDetail", sqlParameters).FirstOrDefault();
        }

        public IEnumerable<GetAnswersInQuestion> GetAnswersInQuestion(Guid questionId)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@TestQuestionId", questionId)
            };
            return CallSqlFunction<GetAnswersInQuestion>("GetAllAnswerInQuestion", sqlParameters);
        }

        public void AddAnswer(AddAnswer addAnswer)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@Answer", addAnswer.Answer),
                new SqlParameter("@IsTrueAnswer", addAnswer.IsTrueAnswer),
                new SqlParameter("@TestQuestionId", addAnswer.QuestionId)
            };
            CallSqlProcedure("AddAnswer", sqlParameters);
        }

        public void UpdateAnswer(UpdateAnswer updateAnswer)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@Answer",  updateAnswer.Answer),
                new SqlParameter("@IsTrueAnswer", updateAnswer.IsTrueAnswer),
                new SqlParameter("@AnswerId", updateAnswer.AnswerId)
            };
            CallSqlProcedure("UpdateAnswer", sqlParameters);
        }
    }
}
