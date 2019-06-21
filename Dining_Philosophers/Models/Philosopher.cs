using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dining_Philosophers.Models
{
	class Philosopher
	{
		public int PhilosopherID { get; set; }
		public string Name { get; set; }
		public int PlaceAtTable { get; set; }
		public Fork LeftHand { get; set; }
		public Fork RightHand { get; set; }

		public string Eat()
		{
			return string.Empty;
		}
	}
}
