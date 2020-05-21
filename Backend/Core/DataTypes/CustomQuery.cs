using System.Collections.Generic;

namespace Core.DataTypes
{
    public class CustomQuery
    {
        public string TableName { get; set; }
        public List<QueryColumn> Columns { get; set; }

        public List<string> BeforeQuery { get; set; }
        public CustomQuery()
        {
            BeforeQuery = new List<string>();
        }
    }
}
