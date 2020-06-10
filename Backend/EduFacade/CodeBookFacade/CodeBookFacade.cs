using EduFacade.CodeBookFacade.Convertor;
using EduServices.CodeBookService;
using Model.Tables.CodeBook;
using System.Collections.Generic;
using WebModel.CodeBookDto;

namespace EduFacade.CodeBookFacade
{
    public class CodeBookFacade : BaseFacade, ICodeBookFacade
    {
        private readonly ICodeBookService _codeBookService;
        private readonly ICodeBookConvertor _codeBookConvertor;
        public CodeBookFacade(ICodeBookService codeBookService, ICodeBookConvertor codeBookConvertor)
        {
            _codeBookService = codeBookService;
            _codeBookConvertor = codeBookConvertor;
        }

        public HashSet<GetCodeBookItemsDto> GetCodeBookItems(string codeBookName)
        {
            switch (codeBookName)
            {
                case "cb_license":
                    {
                        return _codeBookConvertor.ConvertToWebModel(_codeBookService.GetCodeBookItems<License>());
                    }
                case "cb_coursetype":
                    {
                        return _codeBookConvertor.ConvertToWebModel(_codeBookService.GetCodeBookItems<CourseType>());
                    }
                case "cb_coursestatus":
                    {
                        return _codeBookConvertor.ConvertToWebModel(_codeBookService.GetCodeBookItems<CourseStatus>());
                    }
                case "cb_timetable":
                    {
                        return _codeBookConvertor.ConvertToWebModel(_codeBookService.GetCodeBookItems<TimeTable>());
                    }
                case "cb_country":
                    {
                        return _codeBookConvertor.ConvertToWebModel(_codeBookService.GetCodeBookItems<Country>());
                    }
                case "cb_addresstype":
                    {
                        return _codeBookConvertor.ConvertToWebModel(_codeBookService.GetCodeBookItems<AddressType>());
                    }
                case "cb_answermode":
                    {
                        return _codeBookConvertor.ConvertToWebModel(_codeBookService.GetCodeBookItems<AnswerMode>());
                    }
                case "cb_courselessonitemtemplate":
                    {
                        return _codeBookConvertor.ConvertToWebModel(_codeBookService.GetCodeBookItems<CourseLessonItemTemplate>());
                    }
            }
            return null;
        }
    }
}
