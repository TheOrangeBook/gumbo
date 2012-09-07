using System;
using System.Collections;
using System.Collections.Generic;

namespace gumbo
{
    public static class GumboCaster
    {
        public static T Convert<T>(object value)
        {
            return default(T);
        }
    }

    public class GumboProperty
    {
        //persistance BS
        public Guid Id { get; set; }
        public Guid ObjectId { get; set; }
        public DateTime EffectiveStart { get; set; }
        public DateTime? EffectiveEnd { get; set; }
        public Guid TenantId { get; set; }
        public bool Active { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public object Value { get; set; }

        public T Get<T>()
        {
            return GumboCaster.Convert<T>(Value);
        }

        public void Set<T>(T value)
        {
            Value = value;
        }
    }

    public class GumboObject
    {
        //snow flake?
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }




        public string Type { get; set; }
        public GumboBag Data { get; set; }

        public T As<T>() where T:class
        {
            return Data.As<T>();
        }

    }

    public class GumboBag : IEnumerable<GumboProperty>
    {
        private IList<GumboProperty> _properties;

        public GumboBag()
        {
            _properties = new List<GumboProperty>();
        }

        public IEnumerator<GumboProperty> GetEnumerator()
        {
            return _properties.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T As<T>() where T : class
        {
            //dynamic code here
            return default(T);
        }

    }
}