using System;
using System.Collections.Generic;
using WebModel.Shared;

namespace WebModel.CategoryDto
{
    public class GetCategoryTreeDto : BaseDto
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public Guid ParentCategory { get; set; }
        public string CategoryIdentificator { get; set; }
        public IEnumerable<GetCategoryTreeDto> ChildCategory { get; set; }
        public GetCategoryTreeDto()
        {
            ChildCategory = new List<GetCategoryTreeDto>();
        }
    }
}
