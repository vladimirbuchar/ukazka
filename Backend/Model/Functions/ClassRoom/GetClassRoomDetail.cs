using System;

namespace Model.Functions
{
    public class GetClassRoomDetail : SqlFunction
    {
        public Guid Id { get; set; }
        public int Floor { get; set; }
        public int MaxCapacity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
