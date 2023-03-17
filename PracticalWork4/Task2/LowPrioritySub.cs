using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class LowPrioritySub : Subscriber
    {
        public override void Subscribe(object sender,Event ev)
        {
            if (ev.Priority < 2)
            {
                Console.WriteLine($"'{ev.Name}' with low priority handled by {nameof(LowPrioritySub)}");
            }
        }
    }
}
