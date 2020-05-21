using Model.Tables.CodeBook;
using System.Collections.Generic;
using WebModel.CodeBookDto;

namespace EduFacade.CodeBookFacade.Convertor
{
    public interface ICodeBookConvertor
    {
        HashSet<GetCodeBookItemsDto> ConvertToWebModel<T>(HashSet<T> codebookItems) where T : CodeBook;
    }
}
