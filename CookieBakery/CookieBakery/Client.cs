using System;
using System.Collections.Generic;
using System.Threading;

namespace CookieBakery
{
    public class Client
    {
        static void Main()
        {
            var baker = new CookieBakery(new BaseCookie());
            var cookieBaker = new Thread(baker.BakeCookies);
            var customerList = new List<Customer> {new Customer("Fred"), new Customer("Ted"), new Customer("Greg")};

            cookieBaker.Start();

            foreach (var customer in customerList)
            {
                new Thread(customer.BuyCookie).Start();
            }

            Thread.Sleep(100);
            while (baker.Running) {}

            foreach (var customer in customerList)
            {
                Console.WriteLine("{0} recieved a total of {1} cookie(s)", customer.GetName(), customer.PurchasedCookies);
            }

            Console.ReadKey(true);
        }
    }
}