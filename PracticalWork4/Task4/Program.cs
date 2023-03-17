using System;
namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var actions = new List<WorkProcess>
            {
                new RunAction("Starting..."),
                new Retention(500),
                new RunAction("Step 1 complete."),
                new Retention(1000),
                new RunAction("Step 2 complete."),
                new Retention(1000),
                new RunAction("Complete.")
            };
            var stateMachine = new Machine(actions);
            stateMachine.Execute();
        }

    }

}