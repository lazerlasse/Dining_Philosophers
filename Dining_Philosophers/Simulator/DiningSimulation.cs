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
		Table table;

		public DiningSimulation(int personsAmount)
		{
			InitializeDiningSimulator(personsAmount);
		}

        // Starts the threads
        public void Start()
        {
            foreach (Thread t in table.PhilosopherThreads)
            {
                t.Start();
            }
        }

        // Resets the threads
        public void Reset()
        {
            foreach (Thread t in table.PhilosopherThreads)
            {
                t.Abort();
            }
        }

        // Changes the speed at which the simulation is playing
        public void Speed()
        {

        }

        // Initializes a table with how many persons is selected 
        private void InitializeDiningSimulator(int personAmount)
        {
            // Initialize table
            table = new Table(personAmount);

            // Assign each thread to a person
            for (int i = 0; i < personAmount; i++)
            {
                // Each thread starts their person.startliving method
                table.PhilosopherThreads[i] = new Thread(new ThreadStart(table.Persons[i].StartLiving))
                {
                    // Names the thread after the order it was 
                    Name = i.ToString()
                };
            }
        }
    }
}
