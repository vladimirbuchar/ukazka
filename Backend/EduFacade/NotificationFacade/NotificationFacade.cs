using EduFacade.NotificationFacade.Convertor;
using EduServices.NotificationService;
using System;
using System.Collections.Generic;
using WebModel.NotificationDto;

namespace EduFacade.NotificationFacade
{
    public class NotificationFacade : BaseFacade, INotificationFacade
    {
        private readonly INotificationService _notificationService;
        private readonly INotificationConvertor _notificationConvertor;
        public NotificationFacade(INotificationService notificationService, INotificationConvertor notificationConvertor)
        {
            _notificationService = notificationService;
            _notificationConvertor = notificationConvertor;

        }
        public HashSet<GetMyNotificationDto> GetMyNotification(Guid userId, bool onlyNew)
        {
            return _notificationConvertor.ConvertToWebModel(_notificationService.GetMyNotification(userId, onlyNew));
        }

        public void SetIsNewNotificationToFalse(Guid userId)
        {
            _notificationService.SetIsNewNotificationToFalse(userId);
        }
    }
}
