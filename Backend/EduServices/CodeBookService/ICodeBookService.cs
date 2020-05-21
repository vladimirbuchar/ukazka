using System.Collections.Generic;

namespace EduServices.CodeBookService
{
    public interface ICodeBookService : IBaseService
    {
        HashSet<T> GetCodeBookItems<T>() where T : Model.Tables.CodeBook.CodeBook;
    }
}
