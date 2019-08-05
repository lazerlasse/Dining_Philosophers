using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dining_Philosophers.Models
{
    public class Philosopher : Person
    {
		public Philosopher(int id, int eatTime)
            : base(id, "Philosopher" + id, eatTime)
		{
		}

		public Philosopher()
			: base()
		{

		}
    }
}
