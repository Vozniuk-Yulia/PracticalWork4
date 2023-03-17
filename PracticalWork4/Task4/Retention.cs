using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class Retention:WorkProcess
    {
        private readonly int milliseconds;

        public Retention(int milliseconds)
        {
            milliseconds = milliseconds;
        }

        public override void Run()
        {
            Thread.Sleep(milliseconds);
            OnAction();
        }
    }
   
}
