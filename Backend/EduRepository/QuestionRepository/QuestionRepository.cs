using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Functions.Question;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EduRepository.QuestionRepository
{
    public class QuestionRepository : BaseRepository, IQuestionRepository
    {
        public QuestionRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {
        }

        public GetQuestionDetail GetQuestionDetail(Guid questionId)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@questionId", questionId)
            };
            return CallSqlFunction<GetQuestionDetail>("GetQuestionDetail", sqlParameters).FirstOrDefault();
        }

        public IEnumerable<GetQuestionsInBank> GetQuestionsInBank(Guid questionBankId)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@BankOfQuestionId", questionBankId)
            };

            return CallSqlFunction<GetQuestionsInBank>("GetQuestionInBank", sqlParameters);
        }
        public void AddQuestion(AddQuestion addQuestion)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@Question", addQuestion.Question),
                new SqlParameter("@AnswerModeId", addQuestion.AnswerModeId),
                new SqlParameter("@BankOfQUestionId", addQuestion.BankOfQUestionId)
            };
            CallSqlProcedure("AddQuestion", sqlParameters);
        }

        public void UpdateQuestion(UpdateQuestion updateQuestion)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@Question", updateQuestion.Question),
                new SqlParameter("@AnswerModeId", updateQuestion.AnswerModeId),
                new SqlParameter("@QuestionId", updateQuestion.Id)
            };
            CallSqlProcedure("UpdateQuestion", sqlParameters);
        }
    }
}
