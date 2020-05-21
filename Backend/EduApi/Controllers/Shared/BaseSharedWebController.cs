using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace EduApi.Controllers.Web
{
    [Route("api/shared/[controller]/[action]")]
    public class BaseSharedWebController : BaseController
    {
        public BaseSharedWebController(ILogger<BaseSharedWebController> logger) : base(logger)
        {

        }
    }
}
