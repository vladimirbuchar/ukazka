namespace EduCore.DataTypes
{
    public class OperationType
    {
        public BaseOperation SelectOperation
        {
            private set; get;
        }
        public bool OrganizationOwner => SelectOperation.OrganizationOwner;
        public bool OrganizationAdministrator => SelectOperation.OrganizationAdministrator;
        public bool CourseAdministrator => SelectOperation.CourseAdministrator;
        public bool CourseEditor => SelectOperation.CourseEditor;
        public bool Lector => SelectOperation.Lector;
        public bool Student => SelectOperation.Student;
        public OperationType(BaseOperation operation)
        {
            SelectOperation = operation;
        }
    }
}