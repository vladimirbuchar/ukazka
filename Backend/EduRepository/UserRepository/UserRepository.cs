using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Functions.Shared;
using Model.Functions.User;
using Model.Tables.CodeBook;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
namespace EduRepository.UserRepository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {
        }

        public LoginUser GetUserToken(string login, string password)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@userName", login),
                new SqlParameter("@password", password),

            };
            return CallSqlFunction<LoginUser>("GetUserToken", parameters).FirstOrDefault();
        }

        public CheckUserEmailExist CheckUserEmailExist(string email)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@userEmail", email),
            };
            return CallSqlFunction<CheckUserEmailExist>("CheckUserEmailExist", parameters).FirstOrDefault();
        }

        public GetUserDetail GetUserDetail(Guid id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id", id)
            };
            return CallSqlFunction<GetUserDetail>("GetUserDetail", parameters).FirstOrDefault();
        }

        public GetUserByAccessToken GetUserByAccessToken(string userAccessToken)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@accessToken", userAccessToken)
            };
            return CallSqlFunction<GetUserByAccessToken>("GetUserByAccessToken", parameters).FirstOrDefault();
        }

        public HashSet<GetUserAddress> GetUserAddress(Guid personId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@personId", personId)
            };
            return CallSqlFunction<GetUserAddress>("GetUserAddress", parameters).ToHashSet();
        }

        public void UpdateUser(UpdateUser user)
        {
            FAddress pernamentAddress = user.Addresses.FirstOrDefault(x => x.AddressTypeIdentificator == AddressTypeValues.PERNAMENT_ADDRESS);
            FAddress mailingAddress = user.Addresses.FirstOrDefault(x => x.AddressTypeIdentificator == AddressTypeValues.MAILING_ADDRESS);
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@FirstName", user.FirstName),
                new SqlParameter("@SecondName", user.SecondName ?? string.Empty),
                new SqlParameter("@LastName", user.LastName),
                new SqlParameter("@UserId", user.UserId),

                new SqlParameter("@paCountry", pernamentAddress.CountryId),
                new SqlParameter("@paRegion", pernamentAddress.Region),
                new SqlParameter("@paCity", pernamentAddress.City),
                new SqlParameter("@paStreet", pernamentAddress.Street),
                new SqlParameter("@paHouseNumber", pernamentAddress.HouseNumber),
                new SqlParameter("@paZipCode", pernamentAddress.ZipCode),

                new SqlParameter("@maCountry", mailingAddress.CountryId),
                new SqlParameter("@maRegion", mailingAddress.Region),
                new SqlParameter("@maCity", mailingAddress.City),
                new SqlParameter("@maStreet", mailingAddress.Street),
                new SqlParameter("@maHouseNumber", mailingAddress.HouseNumber),
                new SqlParameter("@maZipCode", mailingAddress.ZipCode)
            };

            CallSqlProcedure("UpdateUser", sqlParameters);
        }

        public GetUserDetail GetUserDetail(string email)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@userEmail", email)
            };
            return CallSqlFunction<GetUserDetail>("GetUserDetailByEmail", parameters).FirstOrDefault();
        }
    }
}

