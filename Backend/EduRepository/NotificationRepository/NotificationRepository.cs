using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Functions.Notification;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EduRepository.NotificationRepository
{
    public class NotificationRepository : BaseRepository, INotificationRepository
    {
        public NotificationRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {
        }

        public void AddNotification(AddNotification addNotification)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@NotificationTypeId", addNotification.NotificationTypeId),
                new SqlParameter("@ObjectId", addNotification.ObjectId),
                new SqlParameter("@UserId", addNotification.UserId),
                new SqlParameter("@IsNew", addNotification.IsNew)
            };
            CallSqlProcedure("AddNotification", sqlParameters);
        }

        public HashSet<GetMyNotification> GetMyNewNotification(Guid userId)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                { new SqlParameter("@userId", userId) }
            };
            return CallSqlFunction<GetMyNotification>("GetMyNewNotification", sqlParameters).ToHashSet();
        }
        public HashSet<GetMyNotification> GetMyNotification(Guid userId)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                { new SqlParameter("@userId", userId) }
            };
            return CallSqlFunction<GetMyNotification>("GetMyNotification", sqlParameters).ToHashSet();
        }

        public void SetIsNewNotificationToFalse(Guid userId)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@userId", userId)
            };
            CallSqlProcedure("SetIsNewNotificationToFalse", sqlParameters);
        }
    }
}
