using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class EventBus
    {
        private int throttling;
        public int Throttling
        {
            get { return throttling; }
            set { throttling = value; }
        }
        private Dictionary<string, List<Delegate>> handlers = new Dictionary<string, List<Delegate>>();
        private Dictionary<string, DateTime> lastEventTimes = new Dictionary<string, DateTime>();
        public EventBus(int throttling)
        {
            Throttling = throttling;
        }
        public void Register(string eventType, Delegate handler)
        {
            if (!handlers.ContainsKey(eventType))
            {
                handlers.Add(eventType, new List<Delegate>());
            }
            handlers[eventType].Add(handler);
        }

        public void Remove(string eventType, Delegate handler)
        {
            if (handlers.ContainsKey(eventType))
            {
                handlers[eventType].Remove(handler);
            }
        }
        public void Send(string eventType, object sender, EventArgs eventArgs)
        {
            if (handlers.ContainsKey(eventType))
            {
                DateTime lastEventTime;
                if (lastEventTimes.TryGetValue(eventType, out lastEventTime))
                {
                    int time = (int)(DateTime.Now - lastEventTime).TotalMilliseconds;
                    if (time < throttling)
                    {
                        Thread.Sleep(throttling - time);
                    }
                }

                foreach (Delegate handler in handlers[eventType])
                {
                    handler.DynamicInvoke(sender, eventArgs);
                }

                lastEventTimes[eventType] = DateTime.Now;
            }
        }

    }
}
