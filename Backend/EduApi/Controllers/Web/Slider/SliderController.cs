using Core.DataTypes;
using EduFacade.SliderFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebModel.SliderDto;

namespace EduApi.Controllers.Web.Slider
{
    public class SliderController : BaseWebController
    {
        private readonly ISliderFacade _sliderFacade;
        public SliderController(ISliderFacade sliderFacade, ILogger<SliderController> logger) : base(logger)
        {
            _sliderFacade = sliderFacade;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetSliderItemListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        public ActionResult GetSliderItemList()
        {
            try
            {
                return SendResponse(_sliderFacade.GetSliderItemList());
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }
    }
}
