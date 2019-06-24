using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Dining_Philosophers.Models;

namespace Dining_Philosophers.Simulator
{
    public class DiningSimulation : ISimulation
    {

        public void Start()
        {

        }

        public void Stop()
        {

        }

        public void Speed()
        {

        }

        private void InitializeDiningSimulator(int personAmount)
        {
            Table table = new Table();

            for (int i = 0; i < personAmount; i++)
            {
                table.Persons[i] = new Thread(new ThreadStart(Start));
                table.Persons[i].Name = i.ToString();

            }
        }
    }
}
