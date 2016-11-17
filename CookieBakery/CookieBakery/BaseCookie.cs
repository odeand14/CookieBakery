namespace CookieBakery
{
    public class BaseCookie : ICookie
    {
        private readonly string _name;
        private readonly string _bakery;

        public BaseCookie(string name = "Cookie", string bakery = "Johny's Bakery")
        {
            _name = name;
            _bakery = bakery;
        }
        public virtual string GetName()
        {
            return _name;
        }

        public virtual string GetBakery()
        {
            return _bakery;
        }
    }
}