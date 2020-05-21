using EduFacade.SliderFacade.Convertor;
using EduServices.SliderService;
using System.Collections.Generic;
using WebModel.SliderDto;

namespace EduFacade.SliderFacade
{
    public class SliderFacade : BaseFacade, ISliderFacade
    {
        private readonly ISliderService _sliderService;
        private readonly ISliderConvertor _sliderConvertor;
        public SliderFacade(ISliderService sliderService, ISliderConvertor sliderConvertor)
        {
            _sliderService = sliderService;
            _sliderConvertor = sliderConvertor;
        }

        public IEnumerable<GetSliderItemListDto> GetSliderItemList()
        {
            return _sliderConvertor.ConvertToWebModel(_sliderService.GetSliderItemList());
        }
    }
}
