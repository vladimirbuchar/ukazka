using EduCore.DataTypes;

namespace EduCore.EduOperation.ClassRoom
{
    public class GetAllClassRoomInBranchOperation : BaseOperation
    {
        public GetAllClassRoomInBranchOperation() : base("GET_ALL_CLASS_ROOM_IN_BRANCH")
        {
            OrganizationAdministrator = true;
        }
    }
}