using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Dining_Philosophers.Models;

namespace Dining_Philosophers.Simulator
{
    public class SimulationManager
    {
        // Make sizes dynamic later
        Fork[] forks = new Fork[5];
        Thread[] philosopers = new Thread[5];

        public void Start(int personAmount)
        {
            /*
            for (int i = 0; i < personAmount; i++)
            {
                Thread person = new Thread(new ThreadStart(Start));
                person.Name 

            }
            */
        }

        public void Stop()
        {

        }

        public void Speed()
        {

        }

        private void RunSimulation()
        {

        }
    }
}
