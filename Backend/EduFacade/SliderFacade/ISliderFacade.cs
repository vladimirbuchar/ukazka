using System.Collections.Generic;
using WebModel.SliderDto;

namespace EduFacade.SliderFacade
{
    public interface ISliderFacade : IBaseFacade
    {
        IEnumerable<GetSliderItemListDto> GetSliderItemList();
    }
}
