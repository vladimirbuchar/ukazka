using Model.Functions.Notification;
using System;
using System.Collections.Generic;

namespace EduServices.NotificationService
{
    public interface INotificationService : IBaseService
    {
        public void AddNotification(AddNotification addNotification);
        public HashSet<GetMyNotification> GetMyNotification(Guid userId, bool onlyNew);
        void SetIsNewNotificationToFalse(Guid userId);
    }
}
