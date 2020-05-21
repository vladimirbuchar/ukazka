using EduFacade.CourseLectorFacade.Convertor;
using EduServices.CourseLectorService;
using System;
using System.Collections.Generic;
using WebModel.CourseLectorDto;

namespace EduFacade.CourseLectorFacade
{
    public class CourseLectorFacade : BaseFacade, ICourseLectorFacade
    {
        private readonly ICourseLectorService _courseLectorService;
        private readonly ICourseLectorConvertor _courseLectorConvertor;
        public CourseLectorFacade(ICourseLectorService courseLectorService, ICourseLectorConvertor courseLectorConvertor)
        {
            _courseLectorService = courseLectorService;
            _courseLectorConvertor = courseLectorConvertor;
        }
        public void AddCourseLector(AddCourseLectorDto addCourseLectorDto)
        {
            _courseLectorService.AddCourseLector(_courseLectorConvertor.ConvertToBussinessEntity(addCourseLectorDto));
        }

        public void DeleteCourseTermLector(Guid id)
        {
            _courseLectorService.DeleteCourseTermLector(id);
        }

        public List<GetAllLectorCourseTermDto> GetAllLectorCourseTerm(Guid courseTermId)
        {
            return _courseLectorConvertor.ConvertToWebModel(_courseLectorService.GetAllLectorCourseTerm(courseTermId));
        }
    }
}
