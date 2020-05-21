using Core.DataTypes;
using EduFacade.ClassRoomFacade.Convertor;
using EduServices.ClassRoomService;
using Model.Functions.ClassRoom;
using System;
using System.Collections.Generic;
using WebModel.ClassRoomDto;

namespace EduFacade.ClassRoomFacade
{
    public class ClassRoomFacade : BaseFacade, IClassRoomFacade
    {
        private readonly IClassRoomService _classRoomService;
        private readonly IClassRoomConvertor _classRoomConvertor;
        public ClassRoomFacade(IClassRoomService classRoomService, IClassRoomConvertor classRoomConvertor)
        {
            _classRoomService = classRoomService;
            _classRoomConvertor = classRoomConvertor;
        }
        public Result AddClassRoom(AddClassRoomDto addClassRoomDto)
        {
            AddClassRoom addClassRoom = _classRoomConvertor.ConvertToBussinessEntity(addClassRoomDto);
            _classRoomService.AddClassRoom(addClassRoom);
            return new Result();
        }

        public void DeleteClassRoom(Guid classRoomId)
        {
            _classRoomService.DeleteClassRoom(classRoomId);
        }

        public List<GetAllClassRoomInBranchDto> GetAllClassRoomInBranch(Guid branchId)
        {
            return _classRoomConvertor.ConvertToWebModel(_classRoomService.GetAllClassRoomInBranch(branchId));
        }

        public GetClassRoomDetailDto GetClassRoomDetail(Guid classRoomId)
        {
            return _classRoomConvertor.ConvertToWebModel(_classRoomService.GetClassRoomDetail(classRoomId));
        }

        public void UpdateClassRoom(UpdateClassRoomDto updateClassRoomDto)
        {
            UpdateClassRoom updateClassRoom = _classRoomConvertor.ConvertToBussinessEntity(updateClassRoomDto);
            _classRoomService.UpdateClassRoom(updateClassRoom);
        }
    }
}