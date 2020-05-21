using EduCore.DataTypes;

namespace EduCore.EduOperation.ClassRoom
{
    public class DeleteClassRoomOperation : BaseOperation
    {
        public DeleteClassRoomOperation() : base("DELETE_CLASS_ROOM")
        {
            OrganizationAdministrator = true;
        }
    }
}