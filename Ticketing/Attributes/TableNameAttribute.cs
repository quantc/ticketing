using System;

namespace Ticketing.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableNameAttribute : Attribute
    {
        public TableNameAttribute(string name)
        {
            TableName = name;
        }

        public string TableName { get; set; }

    }
}
