using Model.Functions.Slider;
using Model.Tables.Edu;
using System.Collections.Generic;

namespace EduServices.SliderService
{
    public interface ISliderService : IBaseService
    {
        /// <summary>
        /// retrun all items in slider
        /// </summary>
        /// <returns></returns>
        IEnumerable<GetAllSliderItems> GetSliderItemList();

        /// <summary>
        /// create new slider item
        /// </summary>
        /// <param name="sliderItem"></param>
        void Add(Slider sliderItem);
    }

}
