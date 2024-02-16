namespace Application.Interfaces
{
    public interface ICreateCommand<TResult, TData>
    {
        TResult Create(TData data);
    }
}
