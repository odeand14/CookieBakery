using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieBakery
{
    public class NutsAndRaisins : CookieBakery
    {
        public NutsAndRaisins(ICookie baseCookie) : base(baseCookie)
        {
        }

        public override string GetName()
        {
            return base.GetName() + " with nuts and raisins";
        }

        public override string GetBakery()
        {
            return base.GetBakery() + " in Southampton";
        }
    }
}
