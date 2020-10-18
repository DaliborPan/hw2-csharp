using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuScrapper
{ 
    public class DayMenu
    {
        public Soup Soup { get; set; }
        public List<Meal> Meals { get; set; } = new List<Meal>();

        public override string ToString()
        {
            string toReturn = "";
            if (Soup is  null)
            {
                toReturn = "    -Polévka není.\n";
            } else
            {
                toReturn = Soup.ToString() + '\n';
            }   
            
            if (Meals.Count == 0)
            {
                toReturn += "    -Žádná jídla.\n";
                return toReturn;
            }
            int i = 1;
            foreach (var meal in Meals)
            {
                toReturn += "    -" + i + ") " + meal.ToString() + '\n';
                i++;
            }
            return toReturn;
        }
    }

     
}
