using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dining_Philosophers.Models
{
    public class Table : IBowl
    {
        private object forkLock = new object();
        private static Fork[] forks = new Fork[5];
        private Thread[] persons = new Thread[5];


        public Fork[] Forks
        {
            get { return forks; }
            set { forks = value; }
        }
        public Thread[] Persons
        {
            get { return persons; }
            set { persons = value; }
        }

        public Food BowlContent { get; set; }
    }
}
