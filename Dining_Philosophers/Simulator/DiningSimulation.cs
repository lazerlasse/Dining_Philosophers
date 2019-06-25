using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Dining_Philosophers.Models;

namespace Dining_Philosophers.Simulator
{
    public class DiningSimulation : ISimulation
    {
        Thread[] diningThreads = new Thread[5];
        public void Start()
        {
        }

        public void Stop()
        {
            foreach (Thread t in diningThreads)
            {
                t.Abort();
            }
        }

        public void Speed()
        {

        }

        private void InitializeDiningSimulator(int personAmount, Food food)
        {
            Table table = new Table(personAmount, food);

            for (int i = 0; i < personAmount; i++)
            {
                diningThreads[i] = new Thread(new ThreadStart(Start));
                diningThreads[i].Name = i.ToString();
                diningThreads[i].Start();
            }
        }
    }
}
