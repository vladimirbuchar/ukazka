using System;

namespace Model.Functions.Slider
{
    public class GetAllSliderItems : SqlFunction
    {
        public Guid Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }

    }
}
