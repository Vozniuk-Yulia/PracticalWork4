using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class Machine
    {
        private readonly List<WorkProcess> actions;
        private int actionIndex;

        public Machine(List<WorkProcess> actions)
        {
            actions = actions;
            actionIndex = 0;

            foreach (var action in actions)
            {
                action.ActionCompleted += OnAction;
            }
        }

        public void Execute()
        {
            actions[actionIndex].Run();
        }

        private void OnAction(object sender, EventArgs e)
        {
            actionIndex++;

            if (actionIndex < actions.Count)
            {
                actions[actionIndex].Run();
            }
        }
    }
}
