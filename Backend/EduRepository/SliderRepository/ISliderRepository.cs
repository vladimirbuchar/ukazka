using Model.Functions.Slider;
using System.Collections.Generic;

namespace EduRepository.SliderRepository
{
    public interface ISliderRepository : IBaseRepository
    {
        IEnumerable<GetAllSliderItems> GetAllSliderItems();
    }
}
