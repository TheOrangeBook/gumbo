namespace gumbo
{
    public static class GumboCaster
    {
        public static T Convert<T>(object value)
        {
            return default(T);
        }
    }
}