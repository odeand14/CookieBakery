using System;
using System.Threading;

namespace CookieBakery
{
    public class Client
    {

        private readonly Object _cookieLock = new Object();
        static readonly Random _random = new Random();
        private BaseCookie _cookie;
        private ICookie[] _heapOfCookies;
        static readonly string[] dudes = new string[] { "Fred", "Ted", "Greg" };

        public void bakeCookies(Random rand, int cookies)
        {
            _heapOfCookies = new ICookie[cookies];
            for (int i = 0; i < cookies; i++)
            {
                var type = rand.Next(3);
                if (type == 0)
                {
                    _heapOfCookies[i] = new BaseCookie();
                }
                else if (type == 1)
                {
                    _heapOfCookies[i] = new ChoclateChip(_cookie);
                }
                else
                {
                    _heapOfCookies[i] = new NutsAndRaisins(_cookie);
                }
            }

        }

        public void EatCookies()
        {

        }

        public Client()
        {

        }

        static void Main()
        {


            
            Client cli = new Client();
            cli.bakeCookies(_random, 100);

            for (int i = 0; i < dudes.Length; i++)
            {
                Thread t = new Thread(new ThreadStart(cli.EatCookies));
            }




            BaseCookie cookie1 = new BaseCookie();
            Console.Out.WriteLine(cookie1.GetName() + " from " + cookie1.GetBakery());

            ICookie cookie2 = new ChoclateChip(cookie1);

            Console.Out.WriteLine(cookie2.GetName() + " from " + cookie2.GetBakery());

            ICookie cookie3 = new NutsAndRaisins(cookie1);
            Console.Out.WriteLine(cookie3.GetName() + " from " + cookie3.GetBakery());

        }

    }
    /*
    public class CookieGrabber
    {
        private string _name;

        public CookieGrabber(string name)
        {
            _name = name;
        }
    }
    */
}