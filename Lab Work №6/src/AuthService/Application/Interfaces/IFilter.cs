namespace Application.Interfaces
{
    public interface IFilter<T> where T : class
    {
        bool Filter(T value);
    }
}
