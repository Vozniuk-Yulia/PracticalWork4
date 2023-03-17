using System;
using Task2;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var retryPolicy = new Retry(3, 100, 5000, 0.5);
            Publisher publisher = new Publisher();
            LowPrioritySub lowPrioritySubscriber = new LowPrioritySub();
            publisher.Handled += lowPrioritySubscriber.Subscribe;
            Event event1 = new Event();
            event1.Name = "Event 1";
            event1.Priority = 1;
            var operation = new Func<bool>(() =>
            {

                publisher.Publish(event1);
                Thread.Sleep(500);
                return false;
            });

            var success = RetryWithExponentialDelayAndRandomization(operation, retryPolicy);

            Console.WriteLine(success ? "Operation succeeded!" : "Operation failed.");
        }

        static bool RetryWithExponentialDelayAndRandomization(Func<bool> operation, Retry retryPolicy)
        {
            var retriesLeft = retryPolicy.MaxRetries;
            var delayMs = retryPolicy.InitialDelayMs;

            while (retriesLeft > 0)
            {
                Console.WriteLine($"Retrying in {delayMs}ms...");

                Thread.Sleep((int)(delayMs * (1 + retryPolicy.RandomizationFactor * (new Random().NextDouble() * 2 - 1))));

                if (operation())
                {
                    return true;
                }

                retriesLeft--;
                delayMs = Math.Min(delayMs * 2, retryPolicy.MaxDelayMs);
            }

            return false;
        }
    }

}