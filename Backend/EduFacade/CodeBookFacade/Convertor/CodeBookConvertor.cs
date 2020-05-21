using Model.Tables.CodeBook;
using System.Collections.Generic;
using WebModel.CodeBookDto;

namespace EduFacade.CodeBookFacade.Convertor
{
    public class CodeBookConvertor : ICodeBookConvertor
    {
        public HashSet<GetCodeBookItemsDto> ConvertToWebModel<T>(HashSet<T> codebookItems) where T : CodeBook
        {
            HashSet<GetCodeBookItemsDto> data = new HashSet<GetCodeBookItemsDto>();
            foreach (T item in codebookItems)
            {
                data.Add(new GetCodeBookItemsDto()
                {
                    Id = item.Id,
                    IsDefault = item.IsDefault,
                    Name = item.Name,
                    SystemIdentificator = item.SystemIdentificator
                });
            }
            return data;
        }
    }
}
