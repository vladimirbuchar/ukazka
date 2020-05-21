using Core.Extension;

namespace Core.DataTypes
{
    public class ValidationMessage
    {
        private readonly string category;
        private readonly string item;

        public string Code =>
            Value.IsNullOrEmptyWithTrim() ?
            BasicCode :
            string.Format("{0}({1})", BasicCode, Value).ToUpper();
        public string BasicCode => category.IsNullOrEmptyWithTrim() ?
            string.Format("{0}.{1}", Type, item.Trim()).ToUpper() :
            string.Format("{0}.{1}.{2}", Type, category, item).ToUpper();
        public int Priority { get; private set; } = -1;
        public MessageType Type { get; }
        public string Value { get; }
        public ValidationMessage(MessageType group, string category, string item)
        {
            Type = group;
            this.category = category;
            this.item = item;
            SetPriority(group);
        }
        public ValidationMessage(MessageType group, string item)
        {
            Type = group;
            this.item = item;
            SetPriority(group);
        }
        public ValidationMessage(MessageType group, string category, string item, string value)
        {
            Type = group;
            this.category = category;
            this.item = item;
            Value = value;
            SetPriority(group);
        }
        public ValidationMessage(MessageType group, string category, string item, string value, int priority)
        {
            Type = group;
            this.category = category;
            this.item = item;
            Value = value;
            SetPriority(group, priority);
        }
        public ValidationMessage(MessageType group, string category, string item, int priority)
        {
            Type = group;
            this.category = category;
            this.item = item;
            SetPriority(group, priority);
        }
        private void SetPriority(MessageType group)
        {
            SetPriority(group, Priority);
        }
        private void SetPriority(MessageType group, int priority)
        {
            if (priority == -1)
            {
                if (group == MessageType.SYSTEM_ERROR)
                {
                    Priority = 0;
                }
                else if (group == MessageType.ERROR)
                {
                    Priority = 1;
                }
                else if (group == MessageType.WARNING)
                {
                    Priority = 2;
                }
                else
                {
                    Priority = 99999;
                }
            }
            else
            {
                Priority = priority;
            }
        }
    }
}
