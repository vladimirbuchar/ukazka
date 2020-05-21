using Model.Tables.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_BankOfQuestion")]
    public class BankOfQuestion : TableModel
    {
        public virtual BasicInformation BasicInformation { get; set; }
        public virtual ICollection<TestQuestion> TestQuestions { get; set; }
    }
}
