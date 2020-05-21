using System;

namespace Model.Functions.ClassRoom
{
    public class UpdateClassRoom
    {
        public int Floor { get; set; }
        public int MaxCapacity { get; set; }
        public Guid ClassRoomId { get; set; }
        public string BasicInformationName { get; set; }
        public string BasicInformationDescription { get; set; }
    }
}
