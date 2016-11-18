using System;
using System.Collections;
using System.Diagnostics;

namespace CookieBakery
{
    public class CookieBakery : ICookie
    {
        public static ArrayList cookies = new ArrayList();
        private readonly ICookie _baseCookie;

        public ArrayList getCookies()
        {
            return cookies;
        }

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

        public virtual int GetNumber()
        {
            return _baseCookie.GetNumber();
        }

        public void bakeCookies()
        {
            var cookieCounter = 1;
            var time = new Stopwatch();
            time.Start();
            while (cookieCounter < 26)
            {
                Random rand = new Random();
                var type = rand.Next(3);
                if (type == 0)
                {
                    ICookie c = new BaseCookie(cookieCounter);
                    cookies.Add(c);
                    Console.WriteLine(c.GetBakery() + " made " + c.GetName() + " #" + c.GetNumber());
                }
                else if (type == 1)
                {
                    ICookie c = new ChoclateChip(new BaseCookie(cookieCounter));
                    cookies.Add(c);
                    Console.WriteLine(c.GetBakery() + " made " + c.GetName() + " #" + c.GetNumber());
                }
                else
                {
                    ICookie c = new NutsAndRaisins(new BaseCookie(cookieCounter));
                    cookies.Add(c);
                    Console.WriteLine(c.GetBakery() + " made " + c.GetName() + " #" + c.GetNumber());
                }
                while (time.ElapsedMilliseconds < 2000)
                { }
                time.Restart();
                cookieCounter++;
            }
        }
    }
}