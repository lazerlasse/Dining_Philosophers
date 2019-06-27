using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.ComponentModel;

namespace Dining_Philosophers.Models
{
	public abstract class Person : INotifyPropertyChanged
	{
		private int rightForkId;
		private int leftForkId;

		private bool hasLeftFork;

		public int ID { get; set; }
		public string Name { get; set; }
		public bool HasLeftFork
		{
			get { return hasLeftFork; }
			set
			{
				hasLeftFork = value;
				OnPropertyChanged("HasLeftFork");
			}
		}
		public bool HasRightFork { get; set; }
		public int EatTime { get; private set; }

		public Person(int id, string name, int eatTime)
		{
			ID = id;
			Name = name;
			EatTime = eatTime;

			if (ID - 1 == -1)
			{
				rightForkId = Table.Forks.Length - 1;
			}
			else
			{
				rightForkId = ID - 1;
			}

			leftForkId = ID;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void StartLiving()
		{
			while (true)
			{
				// Tries to get a fork for both hands
				if (TryToGetFork())
				{
					// Start eating
					Eat();
				}
				else
				{
					// Remeber to use propertyChanged here
					Think(1000);
				}
			}
		}

		// Method for eating. Dependent on food portion eating time.
		public virtual string Eat()
		{
			// Simulate eating
			Thread.Sleep(EatTime);  // Takes the time to eat from choosen food.
			Monitor.Exit(Table.Forks[leftForkId] = true);
			Monitor.Exit(Table.Forks[rightForkId] = true);
			HasRightFork = false;
			HasLeftFork = false;
			return ID + ": " + Name + " Finished eating";
		}

		// Method for trying to get forks on hand...
		public bool TryToGetFork()
		{
			// Try getting forks clockwise.
			if (Monitor.TryEnter(Table.Forks[leftForkId] = false))
			{
				// Take fork from table to lefthand.
				HasLeftFork = true;

				// Check for right fork.
				if (Monitor.TryEnter(Table.Forks[rightForkId] = false))
				{
					// Take the fork from table to righthand.
					HasRightFork = true;

					// Return succeded the person can now eat.
					return true;
				}
				else
				{
					// Return fork to table..
					Monitor.Exit(Table.Forks[leftForkId] = true);
					HasLeftFork = false;

					// Return not succeded, person can´t eat.
					return false;
				}
			}

			// Try getting forks counter clockwise.
			else
			{
				// Check for right fork.
				if (Monitor.TryEnter(Table.Forks[rightForkId] = false))
				{
					// Take fork from table to right hand..
					HasRightFork = true;

					// Check for left fork.
					if (Monitor.TryEnter(Table.Forks[leftForkId] = false))
					{
						// Take fork from table to lefthand...
						HasLeftFork = true;

						// return succeded, the person can now eat.
						return true;
					}
					else
					{
						// Return fork to table...
						Monitor.Exit(Table.Forks[rightForkId] = true);
						HasRightFork = false;

						// return not succeded, the person can´t eat.
						return false;
					}
				}
				else
				{
					// Return not succeded the person didn´t get a fork.
					return false;
				}
			}
		}

		// Method for persons thinking time before continiue...
		public void Think(int thinkingTime)
		{
			Thread.Sleep(thinkingTime);
		}

		// Notify property changed event.
		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
