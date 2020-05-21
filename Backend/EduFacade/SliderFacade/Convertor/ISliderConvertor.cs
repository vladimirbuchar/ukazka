using Model.Functions.Slider;
using System.Collections.Generic;
using WebModel.SliderDto;

namespace EduFacade.SliderFacade.Convertor
{
    public interface ISliderConvertor
    {
        IEnumerable<GetSliderItemListDto> ConvertToWebModel(IEnumerable<GetAllSliderItems> getAllSliderItems);
    }
}
