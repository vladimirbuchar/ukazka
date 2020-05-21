using EduCore.DataTypes;

namespace EduCore.EduOperation.ClassRoom
{
    public class UpdateClassRoomOperation : BaseOperation
    {
        public UpdateClassRoomOperation() : base("UPDATE_CLASS_ROOM")
        {
            OrganizationAdministrator = true;
        }
    }
}