namespace Application.Session
{
    public abstract class SessionMaker
    {
        private readonly string key;

        public SessionMaker(string key)
        {
            this.key = key;
        }

        public Domain.Session CreateSession()
        {
            var expirationSeconds = GetExpirationSeconds();

            var expirationDate = DateTime.Now.AddSeconds(expirationSeconds);

            return new Domain.Session
            {
                Key = key,
                ExpirationDate = expirationDate,
            };
        }

        protected abstract int GetExpirationSeconds();
    }
}
