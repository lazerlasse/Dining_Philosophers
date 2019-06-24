using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dining_Philosophers.Models
{
    public class Fork
    {
		private int forkID;

		public int ForkID
		{
			get { return forkID; }
			private set { forkID = value; }
		}

		public Fork(int id)
		{
			ForkID = id;
		}
	}
}
