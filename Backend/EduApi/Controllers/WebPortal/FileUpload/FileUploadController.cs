using EduCore.DataTypes;
using EduFacade.AuthFacade;
using EduFacade.FileUploadFacade;
using EduFacade.LicenseFacade;
using EduFacade.OraganizationRoleFacade;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebModel.Shared;

namespace EduApi.Controllers.WebPortal.Course
{
    public class FileUploadController : BaseWebPortalController
    {
        private readonly IFileUploadFacade _fileUploadFacade;
        public FileUploadController(IFileUploadFacade fileUploadFacade, ILogger<FileUploadController> logger, IAuthFacade accessTokenFacade, IOrganizationRoleFacade organizationRoleFacade, ILicenseFacade licenseFacade) : base(logger, accessTokenFacade, organizationRoleFacade, licenseFacade)
        {
            _fileUploadFacade = fileUploadFacade;
        }
        [HttpDelete]
        public IActionResult FileDelete([FromQuery]string accessToken,   [FromQuery] Guid objectId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    ValidateAccessToken = true,
                });
                _fileUploadFacade.FileDelete(objectId);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpPost]
        public IActionResult FileUpload([FromQuery]string accessToken, [FromQuery] Guid objectOwner, IFormFile file)
        {

            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    ValidateAccessToken = true,
                });
                _fileUploadFacade.FileUpload(objectOwner,new List<IFormFile>()
                {
                    file
                });
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }

            
        }





    }
}
