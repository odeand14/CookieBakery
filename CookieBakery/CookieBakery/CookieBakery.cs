using System;
using System.Collections;
using System.Diagnostics;

namespace CookieBakery {
    public class CookieBakery : ICookie {
        private static object _cookieLock = new object();
        private static ArrayList _cookies = new ArrayList();
        private readonly ICookie _baseCookie;

        public ArrayList GetCookies() {
            return _cookies;
        }

        public CookieBakery(ICookie baseCookie) {
            _baseCookie = baseCookie;
        }
        public virtual string GetName() {
            return _baseCookie.GetName();
        }

        public virtual string GetBakery() {
            return _baseCookie.GetBakery();
        }

        public virtual int GetNumber() {
            return _baseCookie.GetNumber();
        }

        public static void SellToCustomer(Customer customer) {
            lock (_cookieLock) {
                if (_cookies.Count != 0) {
                    var c = (ICookie) _cookies[0];
                    var output = customer.GetName() + " recieved " + c.GetBakery() + " " + c.GetName() + " #" + c.GetNumber();
                    Console.WriteLine("{0, 115}", output);
                    _cookies.Remove(c);
                }
            }
        }

        public void BakeCookies() {
            var dailyQuota = 50;
            var cookieCounter = 1;
            var time = new Stopwatch();
            time.Start();
            while (cookieCounter <= dailyQuota) {
                var rand = new Random();
                var type = rand.Next(3);
                ICookie c;

                if (type == 0)
                    c = new BaseCookie(cookieCounter);
                else if (type == 1)
                    c = new ChoclateChip(new BaseCookie(cookieCounter));
                else if (type == 2)
                    c = new Vanilla(new BaseCookie(cookieCounter));
                else
                    c = new NutsAndRaisins(new BaseCookie(cookieCounter));

                _cookies.Add(c);
                Console.WriteLine(c.GetBakery() + " made " + c.GetName() + " #" + c.GetNumber());
                while (time.ElapsedMilliseconds < 667) { }
                time.Restart();
                cookieCounter++;
            }
        }
    }
}
