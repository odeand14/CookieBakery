using System.Threading;

namespace CookieBakery
{
    public class Client
    {
        static void Main()
        {
            CookieBakery baker = new CookieBakery(new BaseCookie());            
            Customer Fred = new Customer("Fred");
            Customer Ted = new Customer("Ted");
            Customer Greg = new Customer("Greg");

            Thread CookieBaker = new Thread(new ThreadStart(baker.bakeCookies));
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