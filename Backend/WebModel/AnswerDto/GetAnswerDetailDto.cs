﻿using System;
using WebModel.Shared;

namespace WebModel.AnswerDto
{
    public class GetAnswerDetailDto : BaseDto
    {
        public Guid Id { get; set; }
        public string Answer { get; set; }
        public bool IsTrueAnswer { get; set; }
    }
}
