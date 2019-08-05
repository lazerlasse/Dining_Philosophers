﻿using System;
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
        // Time to eat in milliseconds
        private int portionEatTime = 5000;


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int PortionEatTime
        {
            get { return portionEatTime; }
            set { portionEatTime = value; }
        }
    }
}
