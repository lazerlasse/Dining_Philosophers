using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dining_Philosophers.Models
{
    public class Table : IBowl
    {
		// Lock object for locking shared resources..
		private readonly object bowlLock = new object();

		// Set table properties..
        private static object[] forkLockObjects;
        private ObservableCollection<Person> persons;
        private static ObservableCollection<bool> forks;
		private Thread[] philosopherThreads;

		// Bowl with food to eat.
		public Food BowlContent { get; set; }

        public static object[] ForkLockObjects
        {
            get { return forkLockObjects; }
            set { forkLockObjects = value; }
        }

        public ObservableCollection<Person> Persons
        {
            get
			{
				return persons;
			}
            set
			{
				persons = value;
			}
        }
        public static ObservableCollection<bool> Forks
        {
            get
            {
                return forks;
            }
            set
            {
                forks = value;
            }
        }

		public Thread[] PhilosopherThreads
		{
			get
			{
				return philosopherThreads;
			}
			set
			{
				philosopherThreads = value;
			}
		}

		// Public Table constructor...
		public Table(int diningPersonCount)
		{
            // Fill bowl with choosen food.
            BowlContent = new Food();
			ForkLockObjects = new object[diningPersonCount];
			Persons = new ObservableCollection<Person>();
            Forks = new ObservableCollection<bool>();

			// Create chosen amount of Philosophers and Forks...
			for (int i = 0; i < diningPersonCount; i++)
			{
				Persons.Insert(i, new Philosopher(i, BowlContent.PortionEatTime));
				ForkLockObjects[i] = new object();
                Forks.Insert(i, true);
			}
        }
	}
}
