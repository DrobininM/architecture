namespace Application.Handlers
{
    public interface ICheckHandler<T>
    {
        bool Handle(T value);

        ICheckHandler<T> Successor { get; }
    }
}
