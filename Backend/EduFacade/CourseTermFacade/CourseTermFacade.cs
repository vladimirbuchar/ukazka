using Core.DataTypes;
using EduFacade.CourseLectorFacade.Convertor;
using EduFacade.CourseTermFacade.Convertor;
using EduServices.ClassRoomService;
using EduServices.CourseLectorService;
using EduServices.CourseTermService;
using Model.Functions;
using Model.Functions.CourseTerm;
using System;
using System.Collections.Generic;
using WebModel.CourseTermDto;
using System.Linq;
using Model.Functions.CourseLector;

namespace EduFacade.CourseTermFacade
{
    public class CourseTermFacade : BaseFacade, ICourseTermFacade
    {
        private readonly ICourseTermService _courseTermService;
        private readonly IClassRoomService _classRoomService;
        private readonly ICourseTermConvertor _courseTermConvertor;
        private readonly ICourseLectorService _courseLectorService;

        public CourseTermFacade(IClassRoomService classRoomService, ICourseTermService courseTermService, ICourseTermConvertor courseTermConvertor, ICourseLectorService courseLectorService)
        {
            _courseTermService = courseTermService;
            _classRoomService = classRoomService;
            _courseTermConvertor = courseTermConvertor;
            _courseLectorService = courseLectorService;
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
                Guid termGuid = _courseTermService.AddCourseTerm(addCourseTerm);
                foreach (var item in addCourseTermDto.Lector)
                {
                    _courseLectorService.AddCourseLector(new Model.Functions.CourseLector.AddCourseLector()
                    {
                        CourseLector = Guid.Parse(item), 
                        CourseTerm = termGuid
                    });
                }
            }
            return result;
        }

        public IEnumerable<GetAllTermInCourseDto> GetAllTermInCourse(Guid courseId)
        {
            return _courseTermConvertor.ConvertToWebModel(_courseTermService.GetAllTermInCourse(courseId));
        }

        public GetCourseTermDetailDto GetCourseTermDetail(Guid courseTermId)
        {
            GetCourseTermDetail getCourseTermDetail = _courseTermService.GetCourseTermDetail(courseTermId);
            GetCourseTermDetailDto getCourseTermDetailDto =   _courseTermConvertor.ConvertToWebModel(getCourseTermDetail);
            getCourseTermDetailDto.Lector = _courseLectorService.GetAllLectorCourseTerm(courseTermId).Select(x => x.Id).ToList();
            return getCourseTermDetailDto;
        }

        public Result UpdateCourseTerm(UpdateCourseTermDto updateCourseTermDto)
        {
            Result validate = Validate(updateCourseTermDto);
            if (validate.IsOk)
            {
                List<CourseTermLector> courseTermLectors = _courseLectorService.GetAllLectorCourseTerm(updateCourseTermDto.Id);
                foreach (var item in courseTermLectors)
                {
                    if (!updateCourseTermDto.Lector.Contains(Convert.ToString(item.Id)))
                    {
                        _courseLectorService.DeleteCourseTermLector(item.LectorId);
                    }
                }
                foreach (var item in updateCourseTermDto.Lector)
                {
                    if (!courseTermLectors.Select(x => x.Id).ToList().Contains(Guid.Parse(item)))
                    {
                        _courseLectorService.AddCourseLector(new AddCourseLector()
                        {
                            CourseLector = Guid.Parse(item),
                            CourseTerm = updateCourseTermDto.Id
                        });
                    }
                }
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
