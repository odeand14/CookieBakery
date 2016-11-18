using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CookieBakery
{
    class Customer
    {
        private string _name;

        public virtual string GetName()
        {
            return _name;
        }

        public Customer(string name)
        {
            _name = name;
        }

        public void buyCookie()
        {
            var Random = new Random();
            var max = Random.Next();
            var time = new Stopwatch();
            time.Start();
            while (true)
            {
                if (CookieBakery.cookies.Count != 0)
                {
                    ICookie c = (ICookie)CookieBakery.cookies[0];
                    Console.WriteLine("\t\t\t\t\t\t" + _name + " recieved " + c.GetName() + " #" + c.GetNumber());
                    CookieBakery.cookies.Remove(c);
                }
                max = Random.Next(0, 2500);
                while (time.ElapsedMilliseconds < 2500) { }
                time.Restart();
            }
        }
    }
}
