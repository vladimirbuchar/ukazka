using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Functions.Slider;
using System.Collections.Generic;
using System.Linq;

namespace EduRepository.SliderRepository
{
    public class SliderRepository : BaseRepository, ISliderRepository
    {
        public SliderRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {
        }


        public IEnumerable<GetAllSliderItems> GetAllSliderItems()
        {
            return CallSqlFunction<GetAllSliderItems>("GetAllSliderItems").OrderByDescending(x => x.Priority);
        }

    }
}
