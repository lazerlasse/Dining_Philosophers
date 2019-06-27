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
        // Intializes a thread
        private Thread[] diningThreads = new Thread[5];

        // Starts the threads
        public void Start()
        {
            foreach (Thread t in diningThreads)
            {
                t.Start();
                t.Join();
            }
        }

        // Resets the threads
        public void Reset()
        {
            foreach (Thread t in diningThreads)
            {
                t.Abort();
            }
        }

        // Changes the speed at which the simulation is playing
        public void Speed()
        {

        }


        // Initializes a table with how many persons is selected 
        public void InitializeDiningSimulator(int personAmount)
        {
            // Initialize table
            Table table = new Table(personAmount);

            // Assign each thread to a person
            for (int i = 0; i < personAmount; i++)
            {
                // Each thread starts their person.startliving method
                diningThreads[i] = new Thread(new ThreadStart(table.Persons[i].StartLiving))
                {
                    // Names the thread after the order it was 
                    Name = i.ToString()
                };
            }
        }
    }
}
