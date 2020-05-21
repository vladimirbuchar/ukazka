using EduRepository.SliderRepository;
using Model.Functions.Slider;
using Model.Tables.Edu;
using System.Collections.Generic;

namespace EduServices.SliderService
{
    public class SliderService : BaseService, ISliderService
    {
        private readonly ISliderRepository _sliderRepository;
        public SliderService(ISliderRepository sliderRepository)
        {
            _sliderRepository = sliderRepository;
        }

        public void Add(Slider sliderItem)
        {
            //sliderRepository.SaveEntity(mapper.Map<Slider>(sliderItem));
        }

        public IEnumerable<GetAllSliderItems> GetSliderItemList()
        {
            return _sliderRepository.GetAllSliderItems();
        }
    }
}
