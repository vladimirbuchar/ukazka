using System.Collections.Generic;
using WebModel.CodeBookDto;

namespace EduFacade.CodeBookFacade
{
    public interface ICodeBookFacade : IBaseFacade
    {
        HashSet<GetCodeBookItemsDto> GetCodeBookItems(string codeBookName);
    }
}
