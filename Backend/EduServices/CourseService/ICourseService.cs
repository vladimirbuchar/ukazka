using Core.DataTypes;
using Model.Functions.Course;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;

namespace EduServices.CourseService
{
    public interface ICourseService : IBaseService
    {
        /// <summary>
        /// create new course
        /// </summary>
        /// <param name="course"></param>
        void AddCourse(AddCourse addCourse);

        /// <summary>
        /// update exists course
        /// </summary>
        /// <param name="course"></param>
        void UpdateCourse(UpdateCourse updateCourse);

        /// <summary>
        /// get detail about course 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        GetCourseDetail GetCourseDetail(Guid courseId);

        /// <summary>
        /// delete course
        /// </summary>
        /// <param name="id"></param>
        void DeleteCourse(Guid courseId);

        /// <summary>
        /// return all course by filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IEnumerable<Course> GetCourseOffer(Course filter);
        List<GetAllCourseInOrganization> GetAllCourseInOrganization(Guid organizationId);
        Result ValidateCourseName(string courseName, Result validate);
        Result ValidatePrice(double price, Result validate);
        Result ValidateCourseType(Guid courseType, Result validate);
        Result ValidateCourseStatus(Guid courseStatus, Result validate);
        Result ValidateStudentCount(int defaultMinimumStudents, int defaultMaximumStudents, Result validate);
    }
}
