using Core.DataTypes;
using Model.Functions.Course;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;
namespace EduRepository.CourseRepository
{
    public interface ICourseRepository : IBaseRepository
    {
        IEnumerable<Course> GetCourseOffer(Guid categoryId, Guid orgId, string city, Guid branch, int maxPrice, Guid courseId, Guid lectorId, Guid classRoomId, bool selectSomeDay, Dictionary<DaysInWeek, bool> selectedDays);
        List<GetAllCourseInOrganization> GetAllCourseInOrganization(Guid organizationId);
        GetCourseDetail GetCourseDetail(Guid courseId);
        void AddCourse(AddCourse addCourse);
        void UpdateCourse(UpdateCourse updateCourse);
    }
}
