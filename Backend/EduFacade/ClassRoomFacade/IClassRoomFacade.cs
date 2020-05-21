using Core.DataTypes;
using System;
using System.Collections.Generic;
using WebModel.ClassRoomDto;

namespace EduFacade.ClassRoomFacade
{
    public interface IClassRoomFacade : IBaseFacade
    {
        Result AddClassRoom(AddClassRoomDto addClassRoomDto);
        List<GetAllClassRoomInBranchDto> GetAllClassRoomInBranch(Guid branchId);
        GetClassRoomDetailDto GetClassRoomDetail(Guid classRoomId);
        void UpdateClassRoom(UpdateClassRoomDto updateClassRoomDto);
        void DeleteClassRoom(Guid classRoomId);
    }
}
