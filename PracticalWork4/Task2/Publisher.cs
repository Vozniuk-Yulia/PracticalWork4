using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Publisher
    {
        public event EventHandler<Event> Handled;

        public void Publish(Event ev)
        {
            Handled?.Invoke(this, ev);
        }
    }
}
