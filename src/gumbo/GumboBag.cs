using System.Collections;
using System.Collections.Generic;

namespace gumbo
{
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

        public void Add(GumboProperty prop)
        {
            _properties.Add(prop);
        }
    }
}