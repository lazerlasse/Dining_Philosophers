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
		private Thread[] diningThreads = new Thread[5];

        public void Start()
        {
            foreach (Thread t in diningThreads)
            {
                t.Start();
                t.Join();
            }
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

        public void InitializeDiningSimulator(int personAmount)
        {
            Table table = new Table(personAmount);

            for (int i = 0; i < personAmount; i++)
            {
                diningThreads[i] = new Thread(new ThreadStart(Start))
                {
                    Name = i.ToString()
                };
            }
        }
    }
}
