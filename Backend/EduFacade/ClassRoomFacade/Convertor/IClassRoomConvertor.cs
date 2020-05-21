using Model.Functions;
using Model.Functions.ClassRoom;
using System.Collections.Generic;
using WebModel.ClassRoomDto;

namespace EduFacade.ClassRoomFacade.Convertor
{
    public interface IClassRoomConvertor
    {
        AddClassRoom ConvertToBussinessEntity(AddClassRoomDto addClassRoomDto);
        UpdateClassRoom ConvertToBussinessEntity(UpdateClassRoomDto updateClassRoomDto);
        List<GetAllClassRoomInBranchDto> ConvertToWebModel(List<GetAllClassRoomInBranch> getAllClassRoomInBranches);
        GetClassRoomDetailDto ConvertToWebModel(GetClassRoomDetail getClassRoomDetail);
    }
}
