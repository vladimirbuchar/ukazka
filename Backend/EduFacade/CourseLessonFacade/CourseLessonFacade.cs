﻿using EduFacade.CourseLessonFacade.Convertor;
using EduServices.CourseChapterService;
using EduServices.CourseService;
using Model.Functions.CourseLesson;
using System;
using System.Collections.Generic;
using WebModel.CourseLesson;

namespace EduFacade.CourseChapterFacade
{
    public class CourseLessonFacade : BaseFacade, ICourseLessonFacade
    {
        private readonly ICourseLessonService _courseLessonService;
        private readonly ICourseLessonConvertor _courseLessonConvertor;
        private readonly IBankOfQuestionService _bankOfQUestionService;
        public CourseLessonFacade(ICourseLessonService courseLessonService, ICourseLessonConvertor courseLessonConvertor)
        {
            _courseLessonService = courseLessonService;
            _courseLessonConvertor = courseLessonConvertor;
        }

        public void AddCourseLesson(AddCourseLessonDto addCourseLessonDto)
        {
            AddCourseLesson addCourseLesson = _courseLessonConvertor.ConvertToBussinessEntity(addCourseLessonDto);
            _courseLessonService.AddCourseLesson(addCourseLesson);
        }

        public void UpdatePositionCourseLesson(UpdatePositionCourseLessonDto updatePositionCourseLesson)
        {
            int position = 0;
            foreach (var item in updatePositionCourseLesson.Ids)
            {
                _courseLessonService.UpdatePositionCourseLesson(new UpdatePositionCourseLesson()
                {
                    Id = Guid.Parse(item),
                    NewPosition = position
                }) ;
                position++;
            }
        }

        public void DeleteCourseLesson(Guid courseLessonId)
        {
            _courseLessonService.DeleteCourseLesson(courseLessonId);
        }

        public List<GetAllLessonInCourseDto> GetAllLessonInCourse(Guid courseId)
        {
            return _courseLessonConvertor.ConvertToWebModel(_courseLessonService.GetAllLessonInCourse(courseId));
        }
        public GetCourseLessonDetailDto GetCourseLessonDetail(Guid courseLessonId)
        {
            return _courseLessonConvertor.ConvertToWebModel(_courseLessonService.GetCourseLessonDetail(courseLessonId));
        }

        public void UpdateCourseLesson(UpdateCourseLessonDto updateCourseLessonDto)
        {
            UpdateCourseLesson updateCourseLesson = _courseLessonConvertor.ConvertToWebModel(updateCourseLessonDto);
            _courseLessonService.UpdateCourseLesson(updateCourseLesson);
        }
    }
}
