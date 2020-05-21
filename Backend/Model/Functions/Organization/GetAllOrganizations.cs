using System;

namespace Model.Functions.Organization
{
    public class GetAllOrganizations : SqlFunction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
    }


}
