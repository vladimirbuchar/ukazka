using Core.DataTypes;
using EduRepository.CourseTermRepository;
using Model.Functions.CourseTerm;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;

namespace EduServices.CourseTermService
{
    public class CourseTermService : BaseService, ICourseTermService
    {
        private readonly ICourseTermRepository _courseTermRepository;

        public CourseTermService(ICourseTermRepository courseTermRepository)
        {
            _courseTermRepository = courseTermRepository;
        }
        public Guid AddCourseTerm(AddCourseTerm addCourseTerm)
        {
            return _courseTermRepository.AddCourseTerm(addCourseTerm);
        }

        public void UpdateCourseTerm(UpdateCourseTerm updateCourseTerm)
        {
            _courseTermRepository.UpdateCourseTerm(updateCourseTerm);
        }

        public void DeleteCourseTerm(Guid courseTermId)
        {
            _courseTermRepository.DeleteEntity<CourseTerm>(courseTermId);
        }

        public IEnumerable<GetAllTermInCourse> GetAllTermInCourse(Guid courseId)
        {
            return _courseTermRepository.GetAllTermInCourse(courseId);
        }

        public GetCourseTermDetail GetCourseTermDetail(Guid courseTermId)
        {
            return _courseTermRepository.GetCourseTermDetail(courseTermId);
        }



        public void ValidateCourseDate(DateTime? activeFrom, DateTime? activeTo, DateTime? registrationFrom, DateTime? registrationTo, Result validate)
        {
            if (registrationFrom != null && registrationTo != null && registrationTo < registrationFrom)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "COURSE_TERM", "REGISTRATION_TO_IS_SMALLER_THEN_REGISTRATION_FROM"));
            }
            if (activeFrom != null && activeTo != null && activeTo < activeFrom)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "COURSE_TERM", "ACTIVE_TO_IS_SMALLER_THEN_ACTIVE_FROM"));
            }
        }
        public void StudentValidation(int minimumStudent, int maximumStudent, int classRoomCapacity, Result validate)
        {
            if (maximumStudent < minimumStudent)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "COURSE_TERM", "MAXIMUM_STUDENTS_IS_LESS_THEN_MINIMUM_STUDENTS"));
            }
            if (maximumStudent > classRoomCapacity)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "COURSE_TERM", "MAXIMUM_STUDENTS_IS_MORE_THEN_CAPACITY_CLASS_ROOM"));
            }
        }
    }
}
