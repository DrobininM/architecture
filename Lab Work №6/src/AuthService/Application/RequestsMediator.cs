namespace Application
{
    public class RequestsMediator
    {
        public IList<IRequestHandler> Handlers { get; } = new List<IRequestHandler>();

        public void Send(object parameter)
        {
            var handlers = Handlers.Where(handler => handler.ParameterType == parameter.GetType());

            foreach (var handler in handlers)
            {
                handler.Handle(parameter);
            }
        }
    }
}
