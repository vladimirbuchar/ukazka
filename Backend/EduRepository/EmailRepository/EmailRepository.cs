using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;

namespace EduRepository.EmailRepository
{
    public class EmailRepository : BaseRepository, IEmailRepository
    {
        public EmailRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {
        }
    }
}
