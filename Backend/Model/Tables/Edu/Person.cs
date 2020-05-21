using Model.Tables.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_Person")]
    public class Person : TableModel
    {
        [Column("FirstName")]
        public virtual string FirstName { get; set; }
        [Column("SecondName")]
        public virtual string SecondName { get; set; }
        [Column("LastName")]
        public virtual string LastName { get; set; }
        public virtual HashSet<Address> PersonAddress { get; set; }
    }

}
