using EduRepository.FileUploadRepository;
using Microsoft.AspNetCore.Http;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduServices.FileUploadService
{
    public class FileUploadService: BaseService, IFileUploadService
    {
        private readonly IFileUploadRepository _fileUploadRepository;
        public FileUploadService(IFileUploadRepository fileUploadRepository)
        {
            _fileUploadRepository = fileUploadRepository;
        }

        public void FileUpload(Guid objectOwner, IList<IFormFile> files)
        {
            _fileUploadRepository.CreateFileRepository(objectOwner);
            
            _fileUploadRepository.DeleteAllFiles(objectOwner);
            foreach (var item in files)
            {
                _fileUploadRepository.FileUpload(objectOwner,item);
            }
        }
        public void FileDelete(Guid objectId)
        {
            _fileUploadRepository.DeleteEntity<FileRepository>(objectId);
        }



    }
}
