using Core.DataTypes;
using EduApi.Controllers.Web;
using EduFacade.CodeBookFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebModel.CodeBookDto;

namespace EduApi.Controllers.Shared.CodeBook
{
    public class CodeBookController : BaseSharedWebController
    {
        private readonly ICodeBookFacade _codeBookFacade;
        public CodeBookController(ILogger<CodeBookController> logger, ICodeBookFacade codeBookFacade) : base(logger)
        {
            _codeBookFacade = codeBookFacade;
        }
        [HttpGet("{codeBookName}")]
        [ProducesResponseType(typeof(IEnumerable<GetCodeBookItemsDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public ActionResult GetCodeBookItems(string codeBookName)
        {
            try
            {
                return SendResponse(_codeBookFacade.GetCodeBookItems(codeBookName));
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }
    }
}
