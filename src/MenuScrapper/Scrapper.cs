using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MenuScrapper
{
    public class Scrapper
    {
        public List<Restaurant> Restaurants { get; set; } = new List<Restaurant>();

        public Scrapper()
        {
            Restaurants.Add(new Restaurant() { RestaurantName = "U Drevaka" });
            Restaurants.Add(new Restaurant() { RestaurantName = "Al Capone" });
            Restaurants.Add(new Restaurant() { RestaurantName = "Bogota" });
            LoadUDrevaka();
            LoadAlCapone();
            LoadBogota();
        }

        public void LoadUDrevaka()
        {
            var html = Utils.GetHtmlDoc(Constants.udrevakaUrl);
            int i = 0;
            DayOfWeek actualDay = DayOfWeek.Monday;
            
            foreach (var node in html.DocumentNode.SelectNodes("//div[@class='row']"))
            {
                if (i == 0)
                {
                    i++;
                    continue;
                }
                if (i == 5)
                {
                    actualDay++;
                    i = 1;
                    if (actualDay == DayOfWeek.Saturday)
                    {
                        break;
                    }
                    continue;
                }
                var line = node.InnerText.Remove(0, node.InnerText.IndexOf(") ") + 1).Split('\n');
                var name = line[0];

                // This try catch block because of f*ucking enter on Thursday last meal
                int price = 0;
                try
                {
                    price = Int32.Parse(Regex.Match(line[1], @"\d+").Value);
                }
                catch (Exception)
                {
                    price = Int32.Parse(Regex.Match(line[2], @"\d+").Value);
                }
               
                Meal meal = new Meal() { Name = name, Price = price };
                Restaurants[0].WeekMenu[actualDay]
                              .Meals
                              .Add(meal);
                i++;
            }
        }

        public void LoadAlCapone()
        {
            var html = Utils.GetHtmlDoc(Constants.alCaponeUrl);

            DayOfWeek actualDay = DateTime.Today.DayOfWeek;
            int i = 0;
            string actualName = "";

            foreach (var node in html.DocumentNode.SelectNodes("//tbody/tr/td/h3"))
            {
                if (i == 0)
                {
                    i++;
                    continue;
                }
                if (i == 1)
                {
                    Soup soup = new Soup() { Name = node.InnerText };
                    Restaurants[1].WeekMenu[actualDay].Soup = soup;
                    i++;
                    continue;
                }
                if (i % 10 == 0)
                {
                    actualDay++;
                    i = 1;
                    if (actualDay == DayOfWeek.Saturday)
                    {
                        break;
                    }
                    continue;
                }
                if (i % 2 == 0)
                {
                    actualName = node.InnerText;
                }
                else
                {
                    Meal meal = new Meal()
                    {
                        Name = actualName,
                        Price = Int32.Parse(node.InnerText.Split(',')[0])
                    };
                    Restaurants[1].WeekMenu[actualDay]
                                  .Meals
                                  .Add(meal);
                }
                i++;
            }
        }

        public void LoadBogota()
        {
            var html = Utils.GetHtmlDoc(Constants.bogotaURL);

            string actualName = "";
            int actualPrice = 0;
            DayOfWeek actualDay = DayOfWeek.Monday;

            int i = 0;
            foreach (var node in html.DocumentNode.SelectNodes("//tr/td"))
            {
                if (i == 0)
                {
                    i++;
                    continue;
                }
                if (i % 19 == 0)
                {
                    actualDay++;
                    i = 1;
                    if (actualDay == DayOfWeek.Saturday)
                    {
                        break;
                    }
                }
                switch (i % 3)
                {
                    case 1:
                        actualName = node.InnerText;
                        break;
                    case 2:
                        actualPrice = Int32.Parse(node.InnerText.Split(',')[0]);
                        break;
                    default:
                        if (i == 3)
                        {
                            Soup soup = new Soup() { Name = actualName, Price = actualPrice };
                            Restaurants[2].WeekMenu[actualDay].Soup = soup;
                        }
                        else
                        {
                           Meal meal = new Meal() { Name = actualName, Price = actualPrice };
                           Restaurants[2].WeekMenu[actualDay]
                                         .Meals
                                         .Add(meal);
                        }    
                        break;
                }
                i++;
            }
        }
    }
}
