namespace Application.Session
{
    public class DefaultUserSessionMaker : SessionMaker
    {
        public DefaultUserSessionMaker(string key) : base(key) { }

        protected override int GetExpirationSeconds()
        {
            return 86400;
        }
    }
}
