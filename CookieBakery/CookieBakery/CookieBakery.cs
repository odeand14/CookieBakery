namespace CookieBakery
{
    public class CookieBakery : ICookie
    {
        private readonly ICookie _baseCookie;

        public CookieBakery(ICookie baseCookie)
        {
            _baseCookie = baseCookie;
        }
        public virtual string GetName()
        {
            return _baseCookie.GetName();
        }

        public virtual string GetBakery()
        {
            return _baseCookie.GetBakery();
        }
    }
}