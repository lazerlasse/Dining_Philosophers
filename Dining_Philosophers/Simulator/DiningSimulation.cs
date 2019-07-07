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
		private Table _table;
		private static readonly object Running = new object();

		public DiningSimulation(int personsAmount, Table table)
		{
			_table = table;
			InitializeDiningSimulator(personsAmount);
		}

		// Starts the threads
		public void Start()
		{
			foreach (Thread t in _table.PhilosopherThreads)
			{
				t.Start();
			}
		}

		// Resets the threads
		public void Pause()
		{
			
		}


		// Initializes a table with how many persons is selected 
		private void InitializeDiningSimulator(int personAmount)
		{
			// Assign each thread to a person
			for (int i = 0; i < personAmount; i++)
			{
				// Each thread starts their person.startliving method
				_table.PhilosopherThreads[i] = new Thread(new ThreadStart(_table.Persons[i].StartLiving))
				{
					// Names the thread after the order it was 
					Name = i.ToString()
				};
			}
		}
	}
}
