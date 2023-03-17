using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal abstract class WorkProcess
    {
        public event EventHandler ActionCompleted;

        public abstract void Run();

        protected void OnAction()
        {
            ActionCompleted?.Invoke(this, EventArgs.Empty);
        }
    }
}
