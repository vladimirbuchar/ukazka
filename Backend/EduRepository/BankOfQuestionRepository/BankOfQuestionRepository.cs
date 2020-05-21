using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Functions.BankOfQuestion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EduRepository.CourseRepository
{
    public class BankOfQuestionRepository : BaseRepository, IBankOfQuestionRepository
    {
        public BankOfQuestionRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {

        }


        public List<GetBankOfQuestionInOrganization> GetBankOfQuestionInOrganization(Guid organizationId)
        {
            return CallSqlFunction<GetBankOfQuestionInOrganization>("GetBankOfQuestionInOrganization", new List<SqlParameter>()
            {
                new SqlParameter("@OrganizationId",organizationId)
            }).ToList();
        }

        public GetBankOfQuestionDetail GetBankOfQuestionDetail(Guid courseId)
        {
            return CallSqlFunction<GetBankOfQuestionDetail>("GetBankOfQuestionDetail", new List<SqlParameter>()
            {
                new SqlParameter("@courseId",courseId)
            }).FirstOrDefault();
        }

        public void AddBankOfQuestion(AddBankOfQuestion addBankOfQuestion)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@BasicInformationName", addBankOfQuestion.Name),
                new SqlParameter("@BasicInformationDescription", addBankOfQuestion.Description),
                new SqlParameter("@OrganizationId", addBankOfQuestion.OrganizationId)

            };
            CallSqlProcedure("CreateBankOfQuestion", sqlParameters);
        }
        public void UpdateBankOfQuestion(UpdateBankOfQuestion updateBankOfQuestion)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@BasicInformationName", updateBankOfQuestion.Name),
                new SqlParameter("@BasicInformationDescription", updateBankOfQuestion.Description),
                new SqlParameter("@BankOfQuestionId", updateBankOfQuestion.BankOfQuestionId)
            };
            CallSqlProcedure("UpdateBankOfQuestion", sqlParameters);
        }
    }
}
