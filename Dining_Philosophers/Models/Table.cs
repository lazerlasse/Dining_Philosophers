using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dining_Philosophers.Models
{
    public class Table : IBowl
    {
        public int ForkPlaceAtTable { get; set; }
        public int PersonPlaceAtTable { get; set; }
        public Food BowlContent { get; set; }
        public int BowlSize { get; set; }
    }
}
