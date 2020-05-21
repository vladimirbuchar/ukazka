using EduRepository.AnswerRepository;
using EduRepository.QuestionRepository;
using EduRepository.StudentTestSummaryRepository;
using EduRepository.TestRepository;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;

namespace EduServices.TestService
{
    public class TestService : BaseService, ITestService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ITestRepository _testRepository;
        private readonly IStudentTestSummaryRepository _studentTestSummaryRepository;
        private readonly IAnswerRepository _answerRepository;
        public TestService(IStudentTestSummaryRepository studentTestSummaryRepository, IQuestionRepository questionRepository, ITestRepository testRepository, IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
            _testRepository = testRepository;
            _studentTestSummaryRepository = studentTestSummaryRepository;
            _questionRepository = questionRepository;
        }

        public void CreateTest(CourseTest request)
        {

            //testRepository.SaveEntity(mapper.Map<CourseTest>(request));
        }


        public void DeleteTest(Guid testId)
        {

            _testRepository.DeleteEntity<CourseTest>(testId);
        }

        public CourseTest EvaluateTest(Guid userTestSummaryId, List<CourseTest> userAnswerRequests)
        {

            CourseTest response = new CourseTest();
            /* StudentTestSummary userTestSummary = studentTestSummaryRepository.GetStudentTestSummary(userTestSummaryId);
             // TestInCourseDetail testDetail = GetTestDetail(userTestSummary.TestId);
             int badQuestions = 0;
             foreach (UserAnswerRequest item in userAnswerRequests)
             {
                 IEnumerable<TestQuestionAnswer> trueAnswers = answerRepository.GetAllAnswerInQuestion(item.QuestionId).Where(x => x.IsTrueAnswer).OrderBy(x => x.Id).ToList();
                 List<Guid> userAnswers = item.UserAnswers.OrderBy(x => x).ToList();
                 EvaluateQuestion q = new EvaluateQuestion()
                 {
                     QuestionId = item.QuestionId,
                     TrueAnswers = trueAnswers.Select(x => x.Id).ToList(),
                     IsOk = userAnswers.Compare(trueAnswers.Select(x => x.Id).ToList())
                 };
                 response.Questions.Add(q);
                 if (!q.IsOk)
                 {
                     badQuestions++;
                 }
             }
             int testQuestionCount = response.Questions.Count();
             int questionOk = testQuestionCount - badQuestions;
             double percent = 0; //testQuestionCount / 100 * testDetail.DesiredSuccess;
             response.TestCompleted = questionOk >= percent;
             userTestSummary.Score = questionOk;
             userTestSummary.Finish = DateTime.Now;
             userTestSummary.TestCompleted = response.TestCompleted;
             studentTestSummaryRepository.SaveEntity(userTestSummary);*/
            return response;
        }

        public CourseTest GenerateTest(Guid testId)
        {
            return new CourseTest();
            /*CourseTest test = GetTestDetail(testId);
            IEnumerable<TestQuestion> questions = _questionRepository.GetQuestionsInBank(testId);

            if (test.IsRandomGenerateQuestion)
            {
                questions = questions.ToList().Shuffle();
            }
            if (test.QuestionCountInTest > 0)
            {
                questions = questions.ToList().Limit(test.QuestionCountInTest);
            }*/

            /*  List<TestQuestion> questionsResult = questions.Select(q => new TestQuestion()
              {
                  Question = q.Question,
                  QuestionId = q.Id,
                  Answers = answerRepository.GetAllAnswerInQuestion(q.Id).Select(a => new TestQuestionAnswer()
                  {
                      Answer = a.Answer,
                      AnswerId = a.Id
                  }).ToList()
              }).ToList();
              return new GenerateTestResponse()
              {
                  Name = test.Name,
                  Questions = questionsResult,
                  TestId = test.Id,
                  TimeLimit = test.TimeLimit
              };*/
        }

        public IEnumerable<CourseTest> GetTestsInCourse(Guid courseId)
        {
            return null;
            /*IEnumerable<CourseTest> result = testRepository.GetAllTestsInCourse(courseId);
            return mapper.Map<IEnumerable<CourseTest>>(result);*/

        }
        public void UpdateTest(CourseTest request)
        {
            CourseTest model = _testRepository.GetEntity<CourseTest>(request.Id);
            _testRepository.SaveEntity(RequestToModel(request, model));
        }

        private CourseTest RequestToModel(CourseTest request, CourseTest model)
        {
            CourseTest m = model ?? new CourseTest();

            m.QuestionCountInTest = request.QuestionCountInTest;
            // m.IsRandomGenerateQuestion = request.RandomGenerateQuestion;
            m.TimeLimit = request.TimeLimit;
            m.DesiredSuccess = request.DesiredSuccess;
            return m;
        }



        public CourseTest GetTestDetail(Guid id)
        {
            return new CourseTest();
            //return mapper.Map<CourseTest>(testRepository.GetEntity<CourseTest>(id));
        }

        public Guid StartTest(Guid testId, Guid userId)
        {

            return _studentTestSummaryRepository.StartTest(new StudentTestSummary()
            {
                StartTime = DateTime.Now,
                //UserId = userId,
                //TestId = testId,
                Finish = null,
                Score = 0,
                TestCompleted = false,

            }).Id;


        }
    }
}
