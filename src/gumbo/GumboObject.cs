using System;

namespace gumbo
{
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
}