using Core.DataTypes;
using EduFacade.CourseTermFacade.Convertor;
using EduServices.ClassRoomService;
using EduServices.CourseTermService;
using Model.Functions;
using Model.Functions.CourseTerm;
using System;
using System.Collections.Generic;
using WebModel.CourseTermDto;

namespace EduFacade.CourseTermFacade
{
    public class CourseTermFacade : BaseFacade, ICourseTermFacade
    {
        private readonly ICourseTermService _courseTermService;
        private readonly IClassRoomService _classRoomService;
        private readonly ICourseTermConvertor _courseTermConvertor;
        public CourseTermFacade(IClassRoomService classRoomService, ICourseTermService courseTermService, ICourseTermConvertor courseTermConvertor)
        {
            _courseTermService = courseTermService;
            _classRoomService = classRoomService;
            _courseTermConvertor = courseTermConvertor;
        }

        private Result Validate(AddCourseTermDto addCourseTermDto)
        {
            Result validation = new Result();
            _courseTermService.ValidateCourseDate(addCourseTermDto.ActiveFrom, addCourseTermDto.ActiveTo, addCourseTermDto.RegistrationFrom, addCourseTermDto.RegistrationTo, validation);
            GetClassRoomDetail classRoomDetail = _classRoomService.GetClassRoomDetail(addCourseTermDto.ClassRoomId);
            _courseTermService.StudentValidation(addCourseTermDto.MinimumStudents, addCourseTermDto.MaximumStudents, classRoomDetail != null ? classRoomDetail.MaxCapacity : 0, validation);
            return validation;
        }

        private Result Validate(UpdateCourseTermDto updateCourseTermDto)
        {
            Result validation = new Result();
            _courseTermService.ValidateCourseDate(updateCourseTermDto.ActiveFrom, updateCourseTermDto.ActiveTo, updateCourseTermDto.RegistrationFrom, updateCourseTermDto.RegistrationTo, validation);
            GetClassRoomDetail classRoomDetail = _classRoomService.GetClassRoomDetail(updateCourseTermDto.ClassRoomId);
            _courseTermService.StudentValidation(updateCourseTermDto.MinimumStudents, updateCourseTermDto.MaximumStudents, classRoomDetail != null ? classRoomDetail.MaxCapacity : 0, validation);
            return validation;
        }

        public Result AddCourseTerm(AddCourseTermDto addCourseTermDto)
        {
            Result result = Validate(addCourseTermDto);
            if (result.IsOk)
            {
                AddCourseTerm addCourseTerm = _courseTermConvertor.ConvertToBussinessEntity(addCourseTermDto);
                _courseTermService.AddCourseTerm(addCourseTerm);
            }
            return result;
        }

        public IEnumerable<GetAllTermInCourseDto> GetAllTermInCourse(Guid courseId)
        {
            return _courseTermConvertor.ConvertToWebModel(_courseTermService.GetAllTermInCourse(courseId));
        }

        public GetCourseTermDetailDto GetCourseTermDetail(Guid courseTermId)
        {
            return _courseTermConvertor.ConvertToWebModel(_courseTermService.GetCourseTermDetail(courseTermId));
        }

        public Result UpdateCourseTerm(UpdateCourseTermDto updateCourseTermDto)
        {
            Result validate = Validate(updateCourseTermDto);
            if (validate.IsOk)
            {
                UpdateCourseTerm updateCourseTerm = _courseTermConvertor.ConvertToWebModel(updateCourseTermDto);
                _courseTermService.UpdateCourseTerm(updateCourseTerm);
            }
            return validate;
        }

        public void DeleteCourseTerm(Guid courseTermId)
        {
            _courseTermService.DeleteCourseTerm(courseTermId);
        }
    }
}
