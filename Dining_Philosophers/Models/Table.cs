﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dining_Philosophers.Models
{
    public class Table : IBowl
    {
        private object forkLock = new object();
        private static Fork[] forks = new Fork[5];
        private Person[] persons = new Person[5];

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

		public Table(int diningPersonCount, Food food)
		{
			// Create chosen amount of Philosophers and Forks...
			for (int i = 0; i < diningPersonCount; i++)
			{
				Persons[i] = new Philosopher(i);
				Forks[i] = new Fork(i);
			}

			// Fill bowl with choosen food.
			BowlContent = food;
		}
    }
}
