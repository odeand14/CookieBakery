using System.Threading;

namespace CookieBakery
{
    public class Client
    {
        static void Main()
        {
            var baker = new CookieBakery(new BaseCookie());            
            var Fred = new Customer("Fred");
            var Ted = new Customer("Ted");
            var Greg = new Customer("Greg");

            var CookieBaker = new Thread(new ThreadStart(baker.BakeCookies));
            var FredGrab = new Thread(new ThreadStart(Fred.BuyCookie));
            var TedGrab = new Thread(new ThreadStart(Ted.BuyCookie));
            var GregGrab = new Thread(new ThreadStart(Greg.BuyCookie));

            CookieBaker.Start();
            FredGrab.Start();
            TedGrab.Start();
            GregGrab.Start();
        }
    }
}