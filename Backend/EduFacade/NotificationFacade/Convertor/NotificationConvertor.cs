using Model.Functions.Notification;
using System.Collections.Generic;
using WebModel.NotificationDto;

namespace EduFacade.NotificationFacade.Convertor
{
    public class NotificationConvertor : INotificationConvertor
    {
        public HashSet<GetMyNotificationDto> ConvertToWebModel(HashSet<GetMyNotification> getMyNotifications)
        {
            HashSet<GetMyNotificationDto> data = new HashSet<GetMyNotificationDto>();
            foreach (GetMyNotification item in getMyNotifications)
            {
                data.Add(new GetMyNotificationDto()
                {
                    Id = item.Id,
                    NotificationIdentificator = item.NotificationIdentificator,
                    ObjectId = item.ObjectId,
                    Data = item.Data,
                    AddDate = item.AddDate,
                    IsNew = item.IsNew
                });
            }
            return data;
        }
    }
}
