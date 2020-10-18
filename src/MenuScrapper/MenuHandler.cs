using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuScrapper
{
    public class MenuHandler
    {
        public Scrapper Scrapper { get; set; }
        public DayOfWeek Today { get; } = DateTime.Today.DayOfWeek;

        public void Program()
        {
            bool run = true;
            while (run)
            {
                switch (RunOption(MainMenu))
                {
                    case 1:
                        RunOption(Option1);
                        break;
                    case 2:
                        RunOption(Option2);
                        break;
                    case 3:
                        RunOption(Option3);
                        break;
                    case 4:
                        RunOption(Option4);
                        break;
                    case 5:
                        RunOption(Option5);
                        break;
                    case 6:
                        RunOption(Option6);
                        break;
                    case 7:
                        run = false;
                        break;
                }
            }
        }

        private int RunOption(Func<int> option)
        {
            try
            {
                return option();
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid option.");
                Console.WriteLine("/*---------------------------------------*/");
                return RunOption(option);
            }
        }

        private int OptionDay()
        {
            int i = 0;
            foreach (var day in Enum.GetValues(typeof(DayOfWeek)))
            {
                if (i == 6)
                {
                    break;
                }
                if (i == 0)
                {
                    i++;
                    continue;
                }
                Console.WriteLine(i + " - " + day);
                i++;
            }
            Console.WriteLine("/* Choose day */");
            int option = Int32.Parse(Console.ReadLine());
            if (option < 1 || option > 5)
            {
                throw new Exception();
            }
            return option;
        }

        private int OptionRestaurant()
        {
            for (int i = 0; i < Scrapper.Restaurants.Count; i++)
            {
                int num = i + 1;
                Console.WriteLine(num + " - " + Scrapper.Restaurants[i].RestaurantName);
            }
            Console.WriteLine("/* Choose restaurant */");
            int option = Int32.Parse(Console.ReadLine());
            if (option < 1 || option > Scrapper.Restaurants.Count)
            {
                throw new Exception();
            }
            return option;
        }

        private int Option6()
        {
            Console.WriteLine("/* Type your word */");
            string input = Console.ReadLine();

            foreach (var restaurant in Scrapper.Restaurants)
            {
                for (int day = 1; day <= 5; day++)
                {
                    for (int meal = 0; meal < restaurant.WeekMenu[(DayOfWeek)day].Meals.Count; meal++)
                    {
                        if (restaurant.WeekMenu[(DayOfWeek)day].Meals[meal].Name.Contains(input))
                        {
                            Console.WriteLine(restaurant.RestaurantName);
                            Console.WriteLine((DayOfWeek)day);
                            Console.WriteLine(restaurant.WeekMenu[(DayOfWeek)day]);
                        }
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("/* Press enter */");
            Console.ReadLine();
            return 1;
        }

        private int Option5()
        {
            foreach (var restaurant in Scrapper.Restaurants)
            {
                for (int day = 1; day <= 5; day++)
                {
                    Console.WriteLine("Restaurant " + restaurant.RestaurantName + " on " + (DayOfWeek)day);
                    Console.WriteLine(restaurant.WeekMenu[(DayOfWeek)day]);
                }
            }
            Console.WriteLine();
            Console.WriteLine("/* Press enter */");
            Console.ReadLine();
            return 1;
        }

        private int Option4()
        {
            int optionRestaurant = OptionRestaurant();
            int optionDay = OptionDay();

            Console.WriteLine("/* You have chosen the restaurant " + Scrapper.Restaurants[optionRestaurant - 1].RestaurantName + " on " + (DayOfWeek)optionDay + " */");
            Console.WriteLine(Scrapper.Restaurants[optionRestaurant - 1].WeekMenu[(DayOfWeek)optionDay]);
            Console.WriteLine();
            Console.WriteLine("/* Press enter */");
            Console.ReadLine();
            return 1;
        }

        private int Option3()
        {
            int option = OptionDay();
            Console.WriteLine("/* You have chosen " + (DayOfWeek)option + " */");

            foreach (var restaurant in Scrapper.Restaurants)
            {
                Console.WriteLine(restaurant.RestaurantName);
                Console.WriteLine(restaurant.WeekMenu[(DayOfWeek)option]);
            }
            Console.WriteLine();
            Console.WriteLine("/* Press enter */");
            Console.ReadLine();
            return 1;
        }

        private int Option2()
        {
            int option = OptionRestaurant();

            Console.WriteLine("/* Today is " + Today + " */");
            Console.WriteLine(Scrapper.Restaurants[option - 1].RestaurantName);
            Console.WriteLine(Scrapper.Restaurants[option - 1].WeekMenu[Today]);
            Console.WriteLine();
            Console.WriteLine("/* Press enter */");
            Console.ReadLine();
            return 1;
        }

        private int Option1()
        {
            Console.WriteLine("/* Today is " + Today + " */");
            for (int i = 0; i < Scrapper.Restaurants.Count; i++)
            {
                Console.WriteLine(Scrapper.Restaurants[i].RestaurantName);
                Console.WriteLine(Scrapper.Restaurants[i].WeekMenu[Today]);
            }
            Console.WriteLine();
            Console.WriteLine("/* Press enter */");
            Console.ReadLine();
            return 1;
        }

        private int MainMenu()
        {
            Console.WriteLine("1 - Print today's menu for all restaurants");
            Console.WriteLine("2 - Print today's menu for restaurant");
            Console.WriteLine("3 - Print menu for all restaurants by day");
            Console.WriteLine("4 - Print menu for restaurant by day");
            Console.WriteLine("5 - Print week menu for all restaurants");
            Console.WriteLine("6 - Search");
            Console.WriteLine("7 - Quit");

            Console.WriteLine("/* Select an option from <1, 7> */");

            int option = Int32.Parse(Console.ReadLine());
            if(option < 1 || option > 7)
            {
                throw new Exception();
            }
            return option;
        }
    }
}
