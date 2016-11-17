﻿using System;

namespace CookieBakery
{
    public class Client
    {
        
        static void Main()
        {
            BaseCookie cookie1 = new BaseCookie();
            Console.Out.WriteLine(cookie1.GetName() + " from " + cookie1.GetBakery());

            ICookie cookie2 = new ChoclateChip(cookie1);

            Console.Out.WriteLine(cookie2.GetName() + " from " + cookie2.GetBakery());

            ICookie cookie3 = new NutsAndRaisins(cookie1);
            Console.Out.WriteLine(cookie3.GetName() + " from " + cookie3.GetBakery());

        }

    }
}