using System;
namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Publisher publisher = new Publisher();
            HighPrioritySub highPrioritySubscriber = new HighPrioritySub();
            MediumPrioritySub mediumPrioritySubscriber = new MediumPrioritySub();
            publisher.Handled += highPrioritySubscriber.Subscribe;
            publisher.Handled += mediumPrioritySubscriber.Subscribe;
            Event event1 = new Event();
            event1.Name = "Event 1";
            event1.Priority = 3;
            Event event2 = new Event();
            event1.Name = "Event 2";
            event1.Priority = 2;
            publisher.Publish(event1);
            publisher.Publish(event2);
         

        }
    }
}