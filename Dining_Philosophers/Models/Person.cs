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

		public Person(int id, string name)
		{
			ID = id;
			Name = name;
		}


		public virtual string Eat(int eatTime)
        {
            // Simulate eating
            Thread.Sleep(eatTime);
            return ID + ": " + Name + " Finished eating";
        }

		public void TryToGetFork(int locationAtTable)
		{
           
		}

		public void Think()
		{

		}
    }
}
