using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.ComponentModel;
using Dining_Philosophers.Simulator;

namespace Dining_Philosophers.Models
{
    public abstract class Person : INotifyPropertyChanged
    {
        private bool hasLeftFork;
        private bool hasRightFork;

        private bool eating;

        private double thinkingTime = 1000;

        private readonly Random Random = new Random();

        // Adjecent fork Id's so that they can be picked up and returned by the correct persons
        public int RightForkId { get; set; }
        public int LeftForkId { get; set; }

        // Id and name property.
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

        // Public property for eating.
        public bool Eating
        {
            get
            {
                return eating;
            }
            set
            {
                eating = value;
                OnPropertyChanged("Eating");
            }
        }

        // Public property for thinking time.
        public double ThinkingTime
        {
            get
            {
                return thinkingTime;
            }
            set
            {
                thinkingTime = value;
                OnPropertyChanged("ThinkingTime");
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
                RightForkId = Table.ForkLockObjects.Length - 1;
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
            while (true)
            {
                DiningSimulation._pauseEvent.WaitOne(Timeout.Infinite);

                if (DiningSimulation._shutdownEvent.WaitOne(0))
                    break;

                // Tries to get a fork for both hands
                if (TryToGetFork())
                {
                    // Start eating
                    Eat();
                }
                else
                {
                    Thread.Sleep(Random.Next(0, 1500));
                }
            }
        }

        // Method for eating. Dependent on food portion eating time.
        public void Eat()
        {
            // Set person eating to true.
            Eating = true;

            // Simulate eating
            Thread.Sleep(EatTime);  // Takes the time to eat from choosen food.

            // Lay forks back on the table...
            Monitor.Exit(Table.ForkLockObjects[LeftForkId]);
            Table.Forks[LeftForkId] = true;
            HasLeftFork = false;

            Monitor.Exit(Table.ForkLockObjects[RightForkId]);
            Table.Forks[RightForkId] = true;
            HasRightFork = false;

            Eating = false;
        }

        // Method for trying to get forks on hand...
        public bool TryToGetFork()
        {
            // Try getting forks clockwise.
            if (Monitor.TryEnter(Table.ForkLockObjects[LeftForkId]))
            {
                // Take fork from table to lefthand.
                HasLeftFork = true;
                Table.Forks[LeftForkId] = false;
                Think();

                // Check for right fork.
                if (Monitor.TryEnter(Table.ForkLockObjects[RightForkId]))
                {
                    // Take the fork from table to righthand.
                    HasRightFork = true;
                    Table.Forks[RightForkId] = false;

                    // Return succeded the person can now eat.
                    return true;
                }
                else
                {
                    // Return fork to table..
                    Monitor.Exit(Table.ForkLockObjects[LeftForkId]);

                    HasLeftFork = false;
                    Table.Forks[LeftForkId] = true;

                    // Return not succeded, person can´t eat.
                    return false;
                }
            }

            // Try getting forks counter clockwise.
            else
            {
                // Check for right fork.
                if (Monitor.TryEnter(Table.ForkLockObjects[RightForkId]))
                {
                    // Take fork from table to right hand..
                    HasRightFork = true;
                    Table.Forks[RightForkId] = false;
                    Think();

                    // Check for left fork.
                    if (Monitor.TryEnter(Table.ForkLockObjects[LeftForkId]))
                    {
                        // Take fork from table to lefthand...
                        HasLeftFork = true;
                        Table.Forks[LeftForkId] = false;

                        // return succeded, the person can now eat.
                        return true;
                    }
                    else
                    {
                        // Return fork to table...
                        Monitor.Exit(Table.ForkLockObjects[RightForkId]);

                        HasRightFork = false;
                        Table.Forks[RightForkId] = true;

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
        public void Think()
        {
            Thread.Sleep(Random.Next(0, (int)thinkingTime));
        }

        // Notify property changed event.
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
