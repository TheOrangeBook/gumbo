using System;

namespace gumbo
{
    public class GumboProperty
    {
        //persistance BS
        public Guid Id { get; set; }
        public Guid ObjectId { get; set; }
        public Guid TenantId { get; set; }
        public bool Active { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public object Value { get; set; }

        public Guid Version { get; set; }

        public T Get<T>()
        {
            return GumboCaster.Convert<T>(Value);
        }

        public void Set<T>(T value)
        {
            Value = value;
        }
    }
}