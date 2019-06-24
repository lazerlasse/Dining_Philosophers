using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dining_Philosophers.Models
{
    public class Food
    {
        // Default Spaghetti
        private string name = "Spaghetti";

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Time to eat in milliseconds
        private int size = 1000;

        public int Size
        {
            get { return size; }
            set { size = value; }
        }
    }
}
