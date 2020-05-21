using Core.DataTypes;
using Model.Functions.CourseStudent;
using System;
using System.Collections.Generic;

namespace EduServices.CourseStudentService
{
    public interface ICourseStudentService : IBaseService
    {


        /// <summary>
        /// add student to course
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="studentId"></param>
        void AddStudentToCourseTerm(AddStudentToCourseTerm addStudentToCourseTerm);
        List<GetAllStudentInCourseTerm> GetAllStudentInCourseTerm(Guid termId);
        void DeleteStudentFromCourseTerm(Guid oid);

        /// <summary>
        /// check that student is in term
        /// </summary>
        /// <param name="termId"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        void IsTermStudent(Guid termId, Guid studentId, Result result);
        void ValidateStudentCount(Guid termId, Result result);
    }
}
