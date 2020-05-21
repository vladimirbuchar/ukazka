using Model.Functions.CourseLesson;
using System.Collections.Generic;
using WebModel.CourseLesson;

namespace EduFacade.CourseLessonFacade.Convertor
{
    public class CourseLessonConvertor : ICourseLessonConvertor
    {
        public AddCourseLesson ConvertToBussinessEntity(AddCourseLessonDto addCourseLessonDto)
        {
            return new AddCourseLesson()
            {
                CourseId = addCourseLessonDto.CourseId,
                Description = addCourseLessonDto.Description,
                Name = addCourseLessonDto.Name
            };
        }

        public List<GetAllLessonInCourseDto> ConvertToWebModel(List<GetAllLessonInCourse> getAllLessonInCourses)
        {
            List<GetAllLessonInCourseDto> data = new List<GetAllLessonInCourseDto>();
            foreach (GetAllLessonInCourse item in getAllLessonInCourses)
            {
                data.Add(new GetAllLessonInCourseDto()
                {
                    Description = item.Description,
                    Name = item.Name,
                    Id = item.Id
                });
            }
            return data;
        }

        public GetCourseLessonDetailDto ConvertToWebModel(GetCourseLessonDetail getCourseLessonDetail)
        {
            return new GetCourseLessonDetailDto()
            {
                Description = getCourseLessonDetail.Description,
                Name = getCourseLessonDetail.Name,
                Id = getCourseLessonDetail.Id
            };
        }

        public UpdateCourseLesson ConvertToWebModel(UpdateCourseLessonDto updateCourseLessonDto)
        {
            return new UpdateCourseLesson()
            {
                Description = updateCourseLessonDto.Description,
                Id = updateCourseLessonDto.Id,
                Name = updateCourseLessonDto.Name
            };
        }
    }
}
