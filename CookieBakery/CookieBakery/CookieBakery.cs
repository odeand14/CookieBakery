using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CookieBakery
{
    public class CookieBakery : ICookie
    {
        private static object _cookieLock = new object();
        private static ArrayList _cookies = new ArrayList();
        private readonly ICookie _baseCookie;
        public bool Running { get; private set; }

        public ArrayList GetCookies()
        {
            return _cookies;
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

        public static bool SellToCustomer(Customer customer)
        {
            lock (_cookieLock)
            {
                if (_cookies.Count == 0) return false;
                var c = (ICookie) _cookies[0];
                var output = customer.GetName() + " recieved " + c.GetBakery() + " " + c.GetName() + " #" + c.GetNumber();
                var rightAlignment = Console.BufferWidth;
                Console.WriteLine("{0, "+ rightAlignment + "}", output);
                _cookies.Remove(c);
                return true;
            }
        }

        public void BakeCookies()
        {
            Running = true;
            var dailyQuota = 25;
            var cookieCounter = new List<int>() {0,0,0,0};
            var time = new Stopwatch();
            time.Start();
            while (cookieCounter.Sum() < dailyQuota)
            {
                var rand = new Random();
                var type = rand.Next(cookieCounter.Count);
                ICookie c;

                if (type == 0)
                    c = new BaseCookie(cookieCounter[0]++);
                else if (type == 1)
                    c = new ChoclateChip(new BaseCookie(cookieCounter[1]++));
                else if (type == 2)
                    c = new Vanilla(new BaseCookie(cookieCounter[2]++));
                else
                    c = new NutsAndRaisins(new BaseCookie(cookieCounter[3]++));

                _cookies.Add(c);
                Console.WriteLine(c.GetBakery() + " made " + c.GetName() + " #" + (c.GetNumber() + 1));
                while (time.ElapsedMilliseconds < 667) { }
                time.Restart();
            }
            Running = false;
            Console.WriteLine("Daily quota of {0} cookies total met. Stopping cookie production :(", dailyQuota);
        }
    }
}
