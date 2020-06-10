using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduServices.FileUploadService
{
    public interface IFileUploadService: IBaseService
    {
        void FileUpload(Guid objectOwner, IList<IFormFile> files);
        void FileDelete(Guid objectId);
    }
}
