using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CookieBakery
{
    public class Customer
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
                CookieBakery.sellToCustomer(this);
                max = Random.Next(0, 2500);
                while (time.ElapsedMilliseconds < max) { }
                time.Restart();
            }
        }
    }
}
