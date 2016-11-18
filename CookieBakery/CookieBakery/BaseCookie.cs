namespace CookieBakery
{
    public class BaseCookie : ICookie
    {
        private readonly string _name;
        private readonly string _bakery;
        private readonly int _number;

        public BaseCookie(int number = 0, string name = "Cookie", string bakery = "Johnny's Bakery")
        {
            _number = number;
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

        public virtual int GetNumber()
        {
            return _number;
        }
    }
}