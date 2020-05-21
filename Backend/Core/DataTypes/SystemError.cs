namespace Core.DataTypes
{
    public class SystemError : ValidationMessage
    {
        public SystemError(string errorCode) : base(MessageType.SYSTEM_ERROR, errorCode)
        {

        }
    }
}