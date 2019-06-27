﻿using System;
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

        // A person has two hands, and each hand can hold a Fork object
        public Fork LeftHand { get; set; }
        public Fork RightHand { get; set; }

        // Specifies how long a person eats for, the bigger the food, the longer the person eats.
        public int EatTime { get; private set; }

        // Constructor
        public Person(int id, string name, int eatTime)
        {
            ID = id;
            Name = name;
            EatTime = eatTime;
        }

        // This method makes a person live, this method is great because a thread can run in here until stopped
        public void StartLiving()
        {
            // Infinite loop
            while (true)
            {
                // Tries to get a fork for both hands
                if(TryToGetFork())
                {
                    // Start eating
                    Eat();
                }
                // If not successfull, think for X amount of time and try agian 
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
            Monitor.Exit(Table.Forks[LeftHand.ForkID]);
            Monitor.Exit(Table.Forks[RightHand.ForkID]);
            RightHand = null;
            LeftHand = null;
            return ID + ": " + Name + " Finished eating";
        }

        // Method for trying to get forks on hand...
        public bool TryToGetFork()
        {
            // Try getting forks clockwise.
            if (Monitor.TryEnter(Table.Forks[ID]))
            {
                // Take fork from table to lefthand.
                LeftHand = Table.Forks[ID];

                // Check id not out of range.
                if (ID - 1 == -1)
                {
                    // Create temporary index id.
                    int tempId = Table.Forks.Length - 1;

                    // Check for right fork.
                    if (Monitor.TryEnter(Table.Forks[tempId]))
                    {
                        // Take the fork from table to righthand.
                        RightHand = Table.Forks[tempId];

                        // Return succeded the person can now eat.
                        return true;
                    }
                    else
                    {
                        // Return fork to table..
                        Monitor.Exit(Table.Forks[LeftHand.ForkID]);
                        LeftHand = null;

                        // Return not succeded, person can´t eat.
                        return false;
                    }
                }
                // Check for right fork
                else
                {
                    // Set Id - 1.
                    int tempId = ID - 1;

                    // Check fork is available.
                    if (Monitor.TryEnter(Table.Forks[tempId]))
                    {
                        // Take fork from table to righthand.
                        RightHand = Table.Forks[tempId];

                        // Return succeded the person can now eat..
                        return true;
                    }
                    else
                    {
                        // Return fork to table.
                        Monitor.Exit(Table.Forks[LeftHand.ForkID]);
                        LeftHand = null;

                        // Return not succeded, the person can´t eat.
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
                if (Monitor.TryEnter(Table.Forks[checkId]))
                {
                    // Take fork from table to right hand..
                    RightHand = Table.Forks[checkId];

                    // Check for left fork.
                    if (Monitor.TryEnter(Table.Forks[ID]))
                    {
                        // Take fork from table to lefthand...
                        LeftHand = Table.Forks[ID];

                        // return succeded, the person can now eat.
                        return true;
                    }
                    else
                    {
                        // Return fork to table...
                        Monitor.Exit(Table.Forks[RightHand.ForkID]);
                        RightHand = null;

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

        // Method for persons think time
        public void Think(int thinkingTime)
        {
            Thread.Sleep(thinkingTime);
        }
    }
}
