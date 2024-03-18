namespace Application.Session
{
    public class AdminSessionMaker : SessionMaker
    {
        public AdminSessionMaker(string key) : base(key) { }

        protected override int GetExpirationSeconds()
        {
            return 43200;
        }
    }
}
