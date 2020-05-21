using EduCore.DataTypes;

namespace EduCore.EduOperation.ClassRoom
{
    public class GetClassRoomDetailOperation : BaseOperation
    {
        public GetClassRoomDetailOperation() : base("GET_CLASS_ROOM_DETAIL")
        {
            OrganizationAdministrator = true;
        }
    }
}