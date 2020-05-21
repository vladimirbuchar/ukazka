using EduRepository.NotificationRepository;
using EduRepository.OrganizationRepository;
using Model.Functions.Notification;
using Model.Functions.Organization;
using Model.Tables.CodeBook;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.NotificationService
{
    public class NotificationService : BaseService, INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IOrganizationRepository _organizationRepository;
        public NotificationService(INotificationRepository notificationRepository, IOrganizationRepository organizationRepository)
        {
            _notificationRepository = notificationRepository;
            _organizationRepository = organizationRepository;
        }
        public void AddNotification(AddNotification addNotification)
        {
            _notificationRepository.AddNotification(addNotification);
        }

        public HashSet<GetMyNotification> GetMyNotification(Guid userId, bool onlyNew)
        {
            HashSet<GetMyNotification> notifications = new HashSet<GetMyNotification>();
            notifications = notifications.OrderByDescending(x => x.AddDate).ToHashSet();
            if (onlyNew)
            {
                notifications = _notificationRepository.GetMyNewNotification(userId);
            }
            else
            {
                notifications = _notificationRepository.GetMyNotification(userId);
            }
            foreach (GetMyNotification item in notifications)
            {
                if (item.NotificationIdentificator == NotificationTypeValues.INVITE_TO_ORGANIZATION)
                {
                    GetOrganizationDetail getOrganizationDetail = _organizationRepository.GetOrganizationDetail(item.ObjectId);
                    item.Data.Add("{organizationName}", getOrganizationDetail.Name);
                }
            }
            return notifications;
        }

        public void SetIsNewNotificationToFalse(Guid userId)
        {
            _notificationRepository.SetIsNewNotificationToFalse(userId);
        }
    }
}
