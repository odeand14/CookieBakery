using System;
using System.Threading;

namespace CookieBakery
{
    public class Client
    {
        public Client()
        {

        }

        static void Main()
        {   
            Client cli = new Client();
            CookieBakery baker = new CookieBakery(new BaseCookie());
            Thread CookieBaker = new Thread(new ThreadStart(baker.bakeCookies));

            Customer Fred = new Customer("Fred");
            Customer Ted = new Customer("Ted");
            Customer Greg = new Customer("Greg");

            Thread FredGrab = new Thread(new ThreadStart(Fred.buyCookie));
            Thread TedGrab = new Thread(new ThreadStart(Ted.buyCookie));
            Thread GregGrab = new Thread(new ThreadStart(Greg.buyCookie));

            CookieBaker.Start();
            FredGrab.Start();
            TedGrab.Start();
            GregGrab.Start();
        }
    }
}