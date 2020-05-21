using Model.Functions;
using Model.Functions.ClassRoom;
using System;
using System.Collections.Generic;

namespace EduServices.ClassRoomService
{
    public interface IClassRoomService : IBaseService
    {
        /// <summary>
        /// metohod for create new class room in branch
        /// </summary>
        /// <param name="classRoom"></param>
        void AddClassRoom(AddClassRoom addClassRoom);
        /// <summary>
        /// method for update exist classroom
        /// </summary>
        /// <param name="classRoom"></param>
        void UpdateClassRoom(UpdateClassRoom updateClassRoom);
        /// <summary>
        /// return list with all select branch
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>
        List<GetAllClassRoomInBranch> GetAllClassRoomInBranch(Guid branchId);
        /// <summary>
        /// return more information about select classroom
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        GetClassRoomDetail GetClassRoomDetail(Guid classRoomId);
        /// <summary>
        /// method for remove exist classroom
        /// </summary>
        /// <param name="id"></param>
        void DeleteClassRoom(Guid classRoomId);
    }
}
