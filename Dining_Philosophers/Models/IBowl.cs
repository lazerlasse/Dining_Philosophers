using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dining_Philosophers.Models
{
    public interface IBowl
    {
        Food BowlContent { get; set; }
    }
}
