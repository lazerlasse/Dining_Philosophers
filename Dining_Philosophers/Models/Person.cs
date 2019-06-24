using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Dining_Philosophers.Models
{
    public abstract class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Fork LeftHand { get; set; }
        public Fork RightHand { get; set; }

        public virtual string Eat(int foodSize)
        {
            // Simulate eating
            Thread.Sleep(foodSize);
            return ID + ": " + Name + " Finished eating";
        }
    }
}
