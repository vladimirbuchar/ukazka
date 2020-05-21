using System.Collections.Generic;

namespace Core.DataTypes
{
    public class InsertProcedureTableConfig
    {

        public string TableName { get; set; }
        public Dictionary<string, string> InsertColumns { get; set; }
        public bool SaveBasicInformation { get; set; }
        public bool SaveContactInformation { get; set; }
        public bool SaveCoursePrice { get; set; }
        public bool SaveGallery { get; set; }
        public bool SaveStudentCount { get; set; }
        public bool SaveAddress { get; set; }
        public Dictionary<string, string> CustomProcedureParametrs { get; set; }
        public List<CustomInsert> CustomInsert { get; set; }
        public List<CustomUpdate> CustomUpdate { get; set; }
        public List<string> CustomSql { get; set; }
        public InsertProcedureTableConfig()
        {
            InsertColumns = new Dictionary<string, string>();
            CustomProcedureParametrs = new Dictionary<string, string>();
            CustomInsert = new List<CustomInsert>();
            CustomUpdate = new List<CustomUpdate>();
            CustomSql = new List<string>();
        }
    }
}
