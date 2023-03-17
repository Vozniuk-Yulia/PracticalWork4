using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class HighPrioritySub : Subscriber
    {
        public override void Subscribe(object sender, Event ev)
        {
            if (ev.Priority > 2)
            {
                Console.WriteLine($"'{ev.Name}' with high priority handled by {nameof(HighPrioritySub)}");
            }
        }
    }
}
