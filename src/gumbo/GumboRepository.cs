using System;

namespace gumbo
{
    public interface GumboRepository
    {
        GumboBag GetBagFor(Guid id, Guid version);
        GumboBag GetBagFor(Guid id);
        GumboObject GetObject(Guid id, Guid version);
        GumboObject GetObject(Guid id);
    }
}