using Microsoft.VisualBasic.FileIO;
using System;
namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EventBus eventBus = new EventBus(200);
            EventHandler<EventArgs> handler1 = (sender, e) => Console.WriteLine("Handler 1 received");
            EventHandler<EventArgs> handler2 = (sender, e) => Console.WriteLine("Handler 2 received");
            eventBus.Register("event1", handler1);
            eventBus.Register("event1", handler2);
            eventBus.Send("event1", null, EventArgs.Empty);
            eventBus.Send("event2", null, EventArgs.Empty);
            eventBus.Remove("event1", handler2);

        }
    }
}