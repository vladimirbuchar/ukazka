namespace EduCore.DataTypes
{
    public abstract class BaseOperation
    {
        public string OperationCode;
        public bool OrganizationOwner { get; protected set; } = true;
        public bool OrganizationAdministrator { get; protected set; } = false;
        public bool CourseAdministrator { get; protected set; } = false;
        public bool CourseEditor { get; protected set; } = false;
        public bool Lector { get; protected set; } = false;
        public bool Student { get; protected set; } = false;
        public BaseOperation(string operation)
        {
            OperationCode = operation;
        }
        public BaseOperation(string operation, bool allowAllLoggedUser)
        {
            OperationCode = operation;
            if (allowAllLoggedUser)
            {
                Student = true;
                Lector = true;
                CourseEditor = true;
                CourseAdministrator = true;
                OrganizationAdministrator = true;
            }
        }
    }
}