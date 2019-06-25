using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;

namespace Dining_Philosophers.Models
{
    public abstract class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Fork LeftHand { get; set; }
        public Fork RightHand { get; set; }
        public int EatTime { get; private set; }

        public Person(int id, string name, int eatTime)
        {
            ID = id;
            Name = name;
            EatTime = eatTime;
        }

		// Method for eating. Dependent on food portion eating time.
        public virtual string Eat()
        {
            // Simulate eating
            Thread.Sleep(EatTime);	// Takes the time to eat from choosen food.
            return ID + ": " + Name + " Finished eating";
        }

		// Method for trying to get forks on hand...
        public bool TryToGetFork()
        {
            // Try getting forks clockwise.
            if (Table.Forks[ID] != null)
            {
				// Take fork from table to lefthand.
                LeftHand = Table.Forks[ID];
                Table.Forks[ID] = null;		// Setting to null = is taken..

                // Check id not out of range.
                if (ID - 1 == -1)
                {
					// Create temporary index id.
                    int tempId = Table.Forks.Length - 1;

                    // Check for right fork.
                    if (Table.Forks[tempId] != null)
                    {
						// Take the fork from table to righthand.
                        RightHand = Table.Forks[tempId];
                        Table.Forks[tempId] = null;		// Set fork to null on table..

                        // Return succeded.
                        return true;
                    }
                    else
                    {
						// Return fork to table..
                        Table.Forks[LeftHand.ForkID] = LeftHand;
                        LeftHand = null;

                        // Return not succeded.
                        return false;
                    }
                }
                // Check for right fork
                else
                {
					// Set Id - 1.
                    int tempId = ID - 1;

					// Check fork is available.
                    if (Table.Forks[tempId] != null)
                    {
						// Take fork from table to righthand.
                        RightHand = Table.Forks[tempId];
                        Table.Forks[tempId] = null;     // Set to null = fork not available.

						// Return succeded..
						return true;
                    }
					else
					{
						// Return fork to table..
						Table.Forks[LeftHand.ForkID] = LeftHand;
						LeftHand = null;

						// Return not succeded.
						return false;
					}
				}
            }

			// Try getting forks counter clockwise.
            else
            {
                // Temp id to check..
                int checkId;

                // Check id not out of range.
                if (ID - 1 == -1)
                {
                    checkId = Table.Forks.Length - 1;
                }
                else
                {
                    checkId = ID - 1;
                }

                // Check for right fork.
                if (Table.Forks[checkId] != null)
                {
					// Take fork from table to right hand..
                    RightHand = Table.Forks[checkId];
                    Table.Forks[checkId] = null;	// Set to null = Fork not available..

                    // Check for left fork.
                    if (Table.Forks[ID] != null)
                    {
						// Take fork from table to lefthand...
                        LeftHand = Table.Forks[ID];
                        Table.Forks[ID] = null;		// Set to null = Fork not available...
                        
						// return succeded.
                        return true;
                    }
                    else
                    {
						// Return fork to table...
                        Table.Forks[RightHand.ForkID] = RightHand;
                        RightHand = null;

                        // return not succeded.
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
    }
}
