using Model.Functions.Slider;
using System.Collections.Generic;
using WebModel.SliderDto;

namespace EduFacade.SliderFacade.Convertor
{
    public class SliderConvertor : ISliderConvertor
    {
        public IEnumerable<GetSliderItemListDto> ConvertToWebModel(IEnumerable<GetAllSliderItems> getAllSliderItems)
        {
            List<GetSliderItemListDto> data = new List<GetSliderItemListDto>();
            foreach (GetAllSliderItems item in getAllSliderItems)
            {
                data.Add(ConvertItem(item));
            }
            return data;
        }

        private GetSliderItemListDto ConvertItem(GetAllSliderItems item)
        {
            return new GetSliderItemListDto()
            {
                Description = item.Description,
                Image = item.Image,
                Name = item.Name

            };
        }
    }
}
