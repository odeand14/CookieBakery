namespace CookieBakery
{
    public class Vanilla : CookieBakery
    {
        public Vanilla(ICookie baseCookie) : base(baseCookie)
        {
        }

        public override string GetName()
        {
            return base.GetName() + " with vanilla";
        }

        public override string GetBakery()
        {
            return base.GetBakery() + " in Cambridge";
        }
    }
}
