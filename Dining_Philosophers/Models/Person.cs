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
		private bool hasLeftFork;
        private bool hasRightFork;

        // Adjecent fork Id's so that they can be picked up and returned by the correct persons
        public int RightForkId { get; set; }
		public int LeftForkId { get; set; }


		public int ID { get; set; }
		public string Name { get; set; }

        // True when fork is picked up, false if unavailable, has a property changed so that the View is notified when changes occur
		public bool HasLeftFork
		{
			get { return hasLeftFork; }
			set
			{
				hasLeftFork = value;
				OnPropertyChanged("HasLeftFork");
			}
		}
        public bool HasRightFork
        {
            get { return hasRightFork; }
            set
            {
                hasRightFork = value;
                OnPropertyChanged("HasRightFork");
            }
        }
        // Specifies how long a person eats for
		public int EatTime { get; private set; }

		public Person()
		{

		}

		public Person(int id, string name, int eatTime)
		{
			ID = id;
			Name = name;
			EatTime = eatTime;

			if (ID - 1 == -1)
			{
				RightForkId = Table.Forks.Length - 1;
			}
			else
			{
				RightForkId = ID - 1;
			}

			LeftForkId = ID;
		}
        // Property Changed initialization
		public event PropertyChangedEventHandler PropertyChanged;

        // Start living, try to get fork, eat and survive
		public void StartLiving()
		{
            // Infinite loop
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
			Monitor.Exit(Table.Forks[LeftForkId]);
			Monitor.Exit(Table.Forks[RightForkId]);
			HasRightFork = false;
			HasLeftFork = false;
			return ID + ": " + Name + " Finished eating";
		}

		// Method for trying to get forks on hand...
		public bool TryToGetFork()
		{
			// Try getting forks clockwise.
			if (Monitor.TryEnter(Table.Forks[LeftForkId]))
			{
				// Take fork from table to lefthand.
				HasLeftFork = true;

				// Check for right fork.
				if (Monitor.TryEnter(Table.Forks[RightForkId]))
				{
					// Take the fork from table to righthand.
					HasRightFork = true;

					// Return succeded the person can now eat.
					return true;
				}
				else
				{
					// Return fork to table..
					Monitor.Exit(Table.Forks[LeftForkId]);
					HasLeftFork = false;

					// Return not succeded, person can´t eat.
					return false;
				}
			}

			// Try getting forks counter clockwise.
			else
			{
				// Check for right fork.
				if (Monitor.TryEnter(Table.Forks[RightForkId]))
				{
					// Take fork from table to right hand..
					HasRightFork = true;

					// Check for left fork.
					if (Monitor.TryEnter(Table.Forks[LeftForkId]))
					{
						// Take fork from table to lefthand...
						HasLeftFork = true;

						// return succeded, the person can now eat.
						return true;
					}
					else
					{
						// Return fork to table...
						Monitor.Exit(Table.Forks[RightForkId]);
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
