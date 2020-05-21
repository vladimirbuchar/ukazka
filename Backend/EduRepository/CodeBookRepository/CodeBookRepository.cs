using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Tables.CodeBook;
using System;
using System.Collections.Generic;
using System.Linq;
namespace EduRepository.CodeBookRepository
{
    public class CodeBookRepository : BaseRepository, ICodeBookRepository
    {
        public CodeBookRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {

        }

        public HashSet<T> GetCodeBookItems<T>() where T : CodeBook
        {
            string name = string.Format("{0}_cblist", typeof(T).Name);
            HashSet<T> data = GetDataFromCache<T>(name);
            if (data == null)
            {
                data = GetEntities<T>().OrderBy(x => x.Priority).ToHashSet();
                SaveDataToCache(name, data, DateTime.Now.AddMinutes(2));
                return data;
            }
            return data;
        }
    }
}
