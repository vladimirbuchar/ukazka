using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;

namespace EduRepository.RoleRepository
{
    public class RoleRepository : BaseRepository, IRoleRepository
    {
        public RoleRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {
        }

    }
}
