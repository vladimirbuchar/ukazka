using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace EduRepository.FileUploadRepository
{
    public class FileUploadRepository : BaseRepository, IFileUploadRepository
    {
        private readonly string _fileRepositoryPath;
        public FileUploadRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {
            _fileRepositoryPath = string.Format("{0}{1}", Directory.GetCurrentDirectory(), configuration.GetSection("FileRepository").Value);
        }
        public void CreateFileRepository(Guid objectOwner)
        {
            string path = string.Format("{0}{1}", _fileRepositoryPath, objectOwner);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        public void DeleteAllFiles(Guid objectOwner)
        {
            CallSqlProcedure("DeleteAllFilesInFileRepository", new List<SqlParameter>()
            {
                {new SqlParameter("@ObjectOwner",objectOwner) }
            });
        }

        public void FileUpload(Guid objectOwner, IFormFile file)
        {
            string extesion = Path.GetExtension(file.FileName);
            string fileName = string.Format("{0}{1}", Guid.NewGuid().ToString(), extesion);
            string filePath = string.Format("{0}{1}/{2}", _fileRepositoryPath, objectOwner, fileName);
            if (File.Exists(filePath))
            {
                FileUpload(objectOwner, file);
                return;
            }

            using FileStream localFile = File.OpenWrite(filePath);
            using Stream uploadedFile = file.OpenReadStream();
            uploadedFile.CopyTo(localFile);

            CallSqlProcedure("AddFileRepositoryItem", new List<SqlParameter>()
            {
                {new SqlParameter("@ObjectOwner",objectOwner)},
                {new SqlParameter("@FileName",fileName)},
                {new SqlParameter("@OriginalFileName",file.FileName)}
            });

        }
    }
}
