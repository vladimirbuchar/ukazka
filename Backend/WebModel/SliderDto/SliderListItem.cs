using WebModel.Shared;

namespace WebModel.SliderDto
{
    public class GetSliderItemListDto : BaseDto, IBasicInformationDto
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
