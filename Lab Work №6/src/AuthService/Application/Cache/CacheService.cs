namespace Application.Cache
{
    public class CacheService<T> where T : class
    {
        public void Add(object key, T obj) { }

        public T Get(object key)
        {
            return null;
        }
    }
}
