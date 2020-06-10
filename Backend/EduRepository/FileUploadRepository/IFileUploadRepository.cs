using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduRepository.FileUploadRepository
{
    public interface IFileUploadRepository: IBaseRepository
    {
        void FileUpload(Guid objectOwner, IFormFile file);
        void CreateFileRepository(Guid objectOwner);
        void DeleteAllFiles(Guid objectOwner);
    }
}
