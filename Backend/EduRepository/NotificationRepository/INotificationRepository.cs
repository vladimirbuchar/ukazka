using Model.Functions.Notification;
using System;
using System.Collections.Generic;

namespace EduRepository.NotificationRepository
{
    public interface INotificationRepository : IBaseRepository
    {
        void AddNotification(AddNotification addNotification);
        HashSet<GetMyNotification> GetMyNewNotification(Guid userId);
        HashSet<GetMyNotification> GetMyNotification(Guid userId);
        void SetIsNewNotificationToFalse(Guid userId);
    }
}
