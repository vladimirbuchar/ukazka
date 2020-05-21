using EduRepository.ClassRoomRepository;
using Model.Functions;
using Model.Functions.ClassRoom;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;

namespace EduServices.ClassRoomService
{
    public class ClassRoomService : BaseService, IClassRoomService
    {
        private readonly IClassRoomRepository _classRoomRepository;
        public ClassRoomService(IClassRoomRepository classRoomRepository)
        {
            _classRoomRepository = classRoomRepository;
        }
        public void AddClassRoom(AddClassRoom classRoom)
        {
            _classRoomRepository.AddClassRoom(classRoom);
        }
        public void UpdateClassRoom(UpdateClassRoom updateClassRoom)
        {
            _classRoomRepository.UpdateClassRoom(updateClassRoom);
        }

        public void DeleteClassRoom(Guid classRoomId)
        {
            _classRoomRepository.DeleteEntity<ClassRoom>(classRoomId);
        }

        public List<GetAllClassRoomInBranch> GetAllClassRoomInBranch(Guid branchId)
        {
            return _classRoomRepository.GetAllClassRoomInBranch(branchId);
        }

        public GetClassRoomDetail GetClassRoomDetail(Guid classRoomId)
        {
            return _classRoomRepository.GetClassRoomDetail(classRoomId);
        }
    }
}
