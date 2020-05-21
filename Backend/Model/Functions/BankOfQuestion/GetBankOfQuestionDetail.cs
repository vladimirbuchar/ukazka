using System;

namespace Model.Functions.BankOfQuestion
{
    public class GetBankOfQuestionDetail : SqlFunction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
