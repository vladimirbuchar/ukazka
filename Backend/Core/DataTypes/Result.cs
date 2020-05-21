using System.Collections.Generic;
using System.Linq;

namespace Core.DataTypes
{
    public class Result
    {
        private readonly List<ValidationMessage> validationMessages;
        public List<ValidationMessage> Errors => validationMessages
            .Where(x => x.Type == MessageType.ERROR ||
                        x.Type == MessageType.SYSTEM_ERROR)
            .OrderBy(x => x.Priority).ToList();
        public bool IsError => Errors.Count > 0;
        public bool IsOk => !IsError;
        public List<ValidationMessage> Warning => validationMessages
            .Where(x => x.Type == MessageType.WARNING)
            .OrderBy(x => x.Priority).ToList();
        public bool IsWarning => Warning.Count > 0;
        public Result()
        {
            validationMessages = new List<ValidationMessage>();
        }
        public void AddResultStatus(ValidationMessage validationMessage)
        {
            validationMessages.Add(validationMessage);
        }
        public bool Contains(ValidationMessage validationMessage)
        {
            return validationMessages.Where(x => x.BasicCode == validationMessage.BasicCode).ToList().Count > 0;
        }
    }
    public class Result<T> : Result
    {
        public T Data { get; set; }
    }
}