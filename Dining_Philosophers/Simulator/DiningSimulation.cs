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
        // Use manual reset event for pause, resume and stopping threads.
        public static ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
        public static ManualResetEvent _pauseEvent = new ManualResetEvent(true);

        // Reference property to table class.
        private Table _table;

        // Amount of philosophers to eat.
        private int philosophersToEat;

        private static readonly object Running = new object();

        public DiningSimulation(int personsAmount, Table table)
        {
            _table = table;
            philosophersToEat = personsAmount;
        }

        // Starts the threads
        public void Start()
        {
            // Release shutdown event if set.
            _shutdownEvent.Reset();
            _pauseEvent.Set();
            
            // Create new array for dining threads.
            _table.PhilosopherThreads = new Thread[philosophersToEat];

            // Create a thread for each philosopher to eat.
            for (int i = 0; i < philosophersToEat; i++)
            {
                _table.PhilosopherThreads[i] = new Thread(new ThreadStart(_table.Persons[i].StartLiving))
                {
                    Name = i.ToString()
                };
                _table.PhilosopherThreads[i].Start();
            }
        }

        public void Stop()
        {
            _shutdownEvent.Set();
            _pauseEvent.Set();

            foreach (Thread t in _table.PhilosopherThreads)
            {
                t.Join();
            }
        }

        // Resets the threads
        public void Pause()
        {
            _pauseEvent.Reset();
        }

        public void Resume()
        {
            _pauseEvent.Set();
        }
    }
}
