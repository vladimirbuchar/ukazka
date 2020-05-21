using Model.Tables.Edu;
using System;
using System.Collections.Generic;

namespace EduServices.TestService
{
    public interface ITestService : IBaseService
    {
        /// <summary>
        /// return list with course in test
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        IEnumerable<CourseTest> GetTestsInCourse(Guid courseId);
        /// <summary>
        /// create new test
        /// </summary>
        /// <param name="request"></param>
        void CreateTest(CourseTest request);
        /// <summary>
        /// update exist test
        /// </summary>
        /// <param name="request"></param>
        void UpdateTest(CourseTest request);
        /// <summary>
        /// delete test
        /// </summary>
        /// <param name="testId"></param>
        void DeleteTest(Guid testId);
        /// <summary>
        /// return more information about test
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CourseTest GetTestDetail(Guid id);
        /// <summary>
        /// generate test question for students
        /// </summary>
        /// <param name="testId"></param>
        /// <returns></returns>
        CourseTest GenerateTest(Guid testId);
        /// <summary>
        /// Evaluate test
        /// </summary>
        /// <param name="userTestSummaryId"></param>
        /// <param name="userAnswerRequests"></param>
        /// <returns></returns>
        CourseTest EvaluateTest(Guid userTestSummaryId, List<CourseTest> userAnswerRequests);
        /// <summary>
        /// start test 
        /// </summary>
        /// <param name="testId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Guid StartTest(Guid testId, Guid userId);



    }
}
