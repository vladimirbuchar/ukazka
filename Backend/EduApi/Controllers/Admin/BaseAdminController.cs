using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
namespace EduApi.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    public class BaseAdminController : BaseController
    {
        public BaseAdminController(ILogger<BaseAdminController> logger) : base(logger)
        {

        }
    }
}
