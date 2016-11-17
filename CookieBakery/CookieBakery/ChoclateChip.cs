namespace CookieBakery
{
    public class ChoclateChip : CookieBakery
    {
        public ChoclateChip(ICookie baseCookie) : base(baseCookie)
        {
        }

        public override string GetName()
        {
            return base.GetName() + " with Chocolate";
        }

        public override string GetBakery()
        {
            return base.GetBakery() + " in London";
        }
    }
}