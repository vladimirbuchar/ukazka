using Model.Tables.CodeBook;
using System.Collections.Generic;

namespace EduRepository.CodeBookRepository
{
    public interface ICodeBookRepository : IBaseRepository
    {
        HashSet<T> GetCodeBookItems<T>() where T : CodeBook;
    }
}
