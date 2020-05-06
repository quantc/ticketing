using System;

namespace Ticketing.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class QueueNameAttribute : Attribute
    {
        public string QueueName { get; set; }
        public QueueNameAttribute(string name)
        {
            QueueName = name;
        }
    }
}
