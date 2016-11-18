using System;
using System.Collections;
using System.Diagnostics;

namespace CookieBakery
{
    public class CookieBakery : ICookie
    {
        private static Object _cookieLock = new Object();
        private static ArrayList cookies = new ArrayList();
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

        public static void sellToCustomer(Customer customer)
        {
            lock (_cookieLock)
            {
                if (cookies.Count != 0)
                {
                    ICookie c = (ICookie)cookies[0];
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t" + customer.GetName() + " recieved " + c.GetName() + " #" + c.GetNumber());
                    cookies.Remove(c);
                }
            }
        }

        public void bakeCookies()
        {
            var dailyQuota = 50;
            var cookieCounter = 1;
            var time = new Stopwatch();
            time.Start();
            while (cookieCounter <= dailyQuota)
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
                while (time.ElapsedMilliseconds < 1000)
                { }
                time.Restart();
                cookieCounter++;
            }
        }
    }
}