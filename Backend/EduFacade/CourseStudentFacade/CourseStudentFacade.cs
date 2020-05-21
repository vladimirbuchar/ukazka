using Core.DataTypes;
using EduFacade.CourseStudentFacade.Convertor;
using EduServices.CourseStudentService;
using System;
using System.Collections.Generic;
using WebModel.StudentDto;

namespace EduFacade.CourseStudentFacade
{
    public class CourseStudentFacade : BaseFacade, ICourseStudentFacade
    {
        private readonly ICourseStudentService _courseStudentService;
        private readonly ICourseStudentConvertor _courseStudentConvertor;
        public CourseStudentFacade(ICourseStudentService courseStudentService, ICourseStudentConvertor courseStudentConvertor)
        {
            _courseStudentService = courseStudentService;
            _courseStudentConvertor = courseStudentConvertor;
        }
        private Result Validate(AddStudentToCourseTermDto addStudentToCourseDto)
        {
            Result result = new Result();
            _courseStudentService.ValidateStudentCount(addStudentToCourseDto.CourseTermId, result);
            _courseStudentService.IsTermStudent(addStudentToCourseDto.CourseTermId, addStudentToCourseDto.UserId, result);
            return result;
        }

        public Result AddStudentToCourseTerm(AddStudentToCourseTermDto addStudentToCourseTermDto)
        {
            Result result = Validate(addStudentToCourseTermDto);
            if (result.IsOk)
            {
                _courseStudentService.AddStudentToCourseTerm(_courseStudentConvertor.ConvertToBussinessEntity(addStudentToCourseTermDto));
            }
            return result;
        }

        public void DeleteStudentFromCourseTerm(Guid studentCourseTermId)
        {
            _courseStudentService.DeleteStudentFromCourseTerm(studentCourseTermId);
        }

        public List<GetAllStudentInCourseTermDto> GetAllStudentInCourseTerm(Guid courseTermId)
        {
            return _courseStudentConvertor.ConvertToWebModel(_courseStudentService.GetAllStudentInCourseTerm(courseTermId));
        }
    }
}
