using Dining_Philosophers.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dining_Philosophers.Helpers
{
    public static class FillTableClothCollection
    {
        public static ObservableCollection<TableCloth> FillCollection()
        {
            ObservableCollection<TableCloth> cloths = new ObservableCollection<TableCloth>();

            TableCloth[] tableCloths =
            {
                new TableCloth("Dug 1", "/Images/TableCloth1.png"),
                new TableCloth("Dug 2", "/Images/TableCloth2.png"),
                new TableCloth("Dug 3", "/Images/TableCloth3.png"),
                new TableCloth("Dug 4", "/Images/TableCloth4.png"),
            };

            foreach (TableCloth cloth in tableCloths)
            {
                cloths.Add(cloth);
            }

            return cloths;
        }
    }
}
