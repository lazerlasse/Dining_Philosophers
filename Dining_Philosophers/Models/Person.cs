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


        public virtual string Eat()
        {
            // Simulate eating
            Thread.Sleep(EatTime);
            return ID + ": " + Name + " Finished eating";
        }

        public void TryToGetFork()
        {
            // Check for left fork
            if (Table.Forks[ID] != null)
            {
                LeftHand = Table.Forks[ID];
                Table.Forks[ID] = null;

                // Check id not out of range.
                if (ID - 1 == -1)
                {
                    int tempId = Table.Forks.Length - 1;

                    // Check for right fork.
                    if (Table.Forks[tempId] != null)
                    {
                        RightHand = Table.Forks[tempId];
                        Table.Forks[tempId] = null;
                        // Return succeded.
                        return;
                    }
                    else
                    {
                        Table.Forks[LeftHand.ForkID] = LeftHand;
                        LeftHand = null;
                        // not succeded.
                        return;
                    }
                }
                // Check for right fork
                else
                {
                    int tempId = ID - 1;

                    if (Table.Forks[tempId] != null)
                    {
                        RightHand = Table.Forks[tempId];
                        Table.Forks[tempId] = null;
                    }
                }
            }
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
                    RightHand = Table.Forks[checkId];
                    Table.Forks[checkId] = null;

                    // Check for left fork.
                    if (Table.Forks[ID] != null)
                    {
                        LeftHand = Table.Forks[ID];
                        Table.Forks[ID] = null;
                        // return succeded.
                        return;
                    }
                    else
                    {
                        Table.Forks[RightHand.ForkID] = RightHand;
                        RightHand = null;
                        // return not succeded.
                        return;
                    }
                }

            }

        }

        public void Think()
        {

        }
    }
}
