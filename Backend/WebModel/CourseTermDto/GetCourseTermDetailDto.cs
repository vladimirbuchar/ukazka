﻿using System;
using System.Collections.Generic;
using WebModel.CourseLectorDto;
using WebModel.Shared;

namespace WebModel.CourseTermDto
{
    public class GetCourseTermDetailDto : BaseDto, IBasicInformationDto
    {
        public Guid Id { get; set; }
        public DateTime ActiveFrom { get; set; }
        public DateTime ActiveTo { get; set; }
        public DateTime RegistrationFrom { get; set; }
        public DateTime RegistrationTo { get; set; }
        public Guid ClassRoomId { get; set; }
        public Guid BranchId { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public Guid TimeFromId { get; set; }
        public string TimeFromValue { get; set; }
        public Guid TimeToId { get; set; }
        public string TimeToValue { get; set; }
        public CoursePriceDto CoursePrice { get; set; }
        public int MaximumStudent { get; set; }
        public int MinimumStudent { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Guid> Lector { get; set; }
    }
}
