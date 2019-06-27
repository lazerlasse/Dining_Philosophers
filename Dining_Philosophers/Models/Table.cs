using System;
using System.Collections.Generic;
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
        private static Fork[] forks = new Fork[4];
        private Person[] persons = new Person[4];

		// Bowl with food to eat.
		public Food BowlContent { get; set; }

        public static Fork[] Forks
        {
            get { return forks; }
            private set { forks = value; }
        }

        public Person[] Persons
        {
            get { return persons; }
            private set { persons = value; }
        }

		// Public Table constructor...
		public Table(int diningPersonCount)
		{
            // Fill bowl with choosen food.
            BowlContent = new Food();

			// Create chosen amount of Philosophers and Forks...
			for (int i = 0; i < diningPersonCount; i++)
			{
				Persons[i] = new Philosopher(i, BowlContent.PortionEatTime);
				Forks[i] = new Fork(i);
			}
        }
    }
}
