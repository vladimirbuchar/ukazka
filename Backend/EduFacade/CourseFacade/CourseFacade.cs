using Core.DataTypes;
using EduFacade.CourseFacade.Convertor;
using EduServices.CourseService;
using Model.Functions.Course;
using System;
using System.Collections.Generic;
using WebModel.CourseDto;

namespace EduFacade.CourseFacade
{
    public class CourseFacade : BaseFacade, ICourseFacade
    {
        private readonly ICourseService _courseService;
        private readonly ICourseConvertor _courseConvertor;
        public CourseFacade(ICourseService courseService, ICourseConvertor courseConvertor)
        {
            _courseService = courseService;
            _courseConvertor = courseConvertor;
        }
        private Result Validate(AddCourseDto addCourseDto)
        {
            Result result = new Result();
            _courseService.ValidateCourseName(addCourseDto.Name, result);
            _courseService.ValidatePrice(addCourseDto.Price.Price, result);
            _courseService.ValidateStudentCount(addCourseDto.DefaultMinimumStudents, addCourseDto.DefaultMaximumStudents, result);
            _courseService.ValidateCourseStatus(addCourseDto.CourseStatusId, result);
            _courseService.ValidateCourseType(addCourseDto.CourseTypeId, result);
            return result;
        }
        private Result Validate(UpdateCourseDto updateCourseDto)
        {
            Result result = new Result();
            _courseService.ValidateCourseName(updateCourseDto.Name, result);
            _courseService.ValidatePrice(updateCourseDto.Price.Price, result);
            _courseService.ValidateStudentCount(updateCourseDto.DefaultMinimumStudents, updateCourseDto.DefaultMaximumStudents, result);
            _courseService.ValidateCourseStatus(updateCourseDto.CourseStatusId, result);
            _courseService.ValidateCourseType(updateCourseDto.CourseTypeId, result);
            return result;
        }

        public Result AddCourse(AddCourseDto addCourseDto)
        {
            Result validate = Validate(addCourseDto);
            if (validate.IsOk)
            {
                AddCourse addCourse = _courseConvertor.ConvertToBussinessEntity(addCourseDto);
                _courseService.AddCourse(addCourse);
            }
            return validate;
        }

        public IEnumerable<GetCourseOfferDto> GetCourseOffer(CourseFilterDto courseFilterDto)
        {
            return new List<GetCourseOfferDto>();
            // return courseService.GetCourseOffer(courseFilter);
        }


        public List<GetAllCourseInOrganizationDto> GetAllCourseInOrganization(Guid organizationId)
        {
            return _courseConvertor.ConvertToWebModel(_courseService.GetAllCourseInOrganization(organizationId));
        }

        public GetCourseDetailDto GetCourseDetail(Guid courseId)
        {
            return _courseConvertor.ConvertToWebModel(_courseService.GetCourseDetail(courseId));
        }

        public Result UpdateCourse(UpdateCourseDto updateCourseDto)
        {
            Result validate = Validate(updateCourseDto);
            if (validate.IsOk)
            {
                UpdateCourse updateCourse = _courseConvertor.ConvertToBussinessEntity(updateCourseDto);
                _courseService.UpdateCourse(updateCourse);
            }
            return validate;
        }

        public void DeleteCourse(Guid courseId)
        {
            _courseService.DeleteCourse(courseId);
        }
    }
}
