﻿using Dining_Philosophers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dining_Philosophers.Simulator
{
    public interface ISimulation
    {
        void Start();
        void Reset();
        void Speed();
    }
}
