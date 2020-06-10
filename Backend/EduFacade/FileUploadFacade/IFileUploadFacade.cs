using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace EduFacade.FileUploadFacade
{
    public interface IFileUploadFacade : IBaseFacade
    {
        void FileUpload(Guid objectOwner, IList<IFormFile> files);
        void FileDelete(Guid objectId);
    }
}
