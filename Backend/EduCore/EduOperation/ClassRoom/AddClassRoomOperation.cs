using EduCore.DataTypes;

namespace EduCore.EduOperation.ClassRoom
{
    public class AddClassRoomOperation : BaseOperation
    {
        public AddClassRoomOperation() : base("ADD_CLASS_ROOM")
        {
            OrganizationAdministrator = true;
        }
    }

}
