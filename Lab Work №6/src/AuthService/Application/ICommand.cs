namespace Application
{
    public interface ICommand<TData>
    {
        void Execute(TData parameter);

        void Cancel();
    }
}
