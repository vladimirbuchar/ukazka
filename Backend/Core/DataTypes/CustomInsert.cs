using System.Collections.Generic;

namespace Core.DataTypes
{
    public class CustomInsert : CustomQuery
    {
        public CustomInsert()
        {
            Columns = new List<QueryColumn>
            {
                new QueryColumn() { ColumnName = "Id", ColumnValue = "NEWID()" },
                new QueryColumn() { ColumnName = "IsDeleted", ColumnValue = 0 },
                new QueryColumn() { ColumnName = "IsSystemObject", ColumnValue = 0 },
                new QueryColumn() { ColumnName = "IsChanged", ColumnValue = 1 },
                new QueryColumn() { ColumnName = "SystemIdentificator", ColumnValue = "null" }
            };
        }
    }
}
