namespace Application
{
    public interface IRequestHandler
    {
        public Type ParameterType { get; }

        public void Handle(object parameter);
    }
}
