using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class RunAction:WorkProcess
    {
        private readonly string message;

        public RunAction(string message)
        {
            message = message;
        }

        public override void Run()
        {
            Console.WriteLine(message);
            OnAction();
        }
    }
}
