using EduRepository.CodeBookRepository;
using Model.Tables.CodeBook;
using System.Collections.Generic;
namespace EduServices.CodeBookService
{
    public class CodeBookService : BaseService, ICodeBookService
    {
        private readonly ICodeBookRepository _codeBookRepository;
        public CodeBookService(ICodeBookRepository codeBookRepository)
        {
            _codeBookRepository = codeBookRepository;
        }

        public HashSet<T> GetCodeBookItems<T>() where T : CodeBook
        {
            return _codeBookRepository.GetCodeBookItems<T>();
        }
    }
}
