using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dining_Philosophers.Models
{
    public class TableCloth
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private string image;

        public string Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
            }
        }

        public TableCloth(string name, string imagePath)
        {
            Name = name;
            Image = imagePath;
        }
    }
}
