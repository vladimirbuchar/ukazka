using Model.Functions;
using Model.Functions.ClassRoom;
using System;
using System.Collections.Generic;
namespace EduRepository.ClassRoomRepository
{
    public interface IClassRoomRepository : IBaseRepository
    {
        List<GetAllClassRoomInBranch> GetAllClassRoomInBranch(Guid branchId);
        GetClassRoomDetail GetClassRoomDetail(Guid classRoomId);
        void AddClassRoom(AddClassRoom addClassRoom);
        void UpdateClassRoom(UpdateClassRoom updateClassRoom);

    }
}
