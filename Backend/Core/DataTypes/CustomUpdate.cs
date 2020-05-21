using System.Collections.Generic;

namespace Core.DataTypes
{
    public class CustomUpdate : CustomQuery
    {
        public List<QueryColumn> WhereColumns = new List<QueryColumn>();

        public CustomUpdate()
        {
            Columns = new List<QueryColumn>();
            WhereColumns = new List<QueryColumn>();
        }
    }
}
