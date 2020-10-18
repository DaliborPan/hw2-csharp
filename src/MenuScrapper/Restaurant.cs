using System;
using System.Collections.Generic;

namespace MenuScrapper
{
    public class Restaurant
    {
        public Dictionary<DayOfWeek, DayMenu> WeekMenu { get; set; }
        public string RestaurantName { get; set; }

        public Restaurant()
        {
            WeekMenu = new Dictionary<DayOfWeek, DayMenu>
            {
                { DayOfWeek.Monday, new DayMenu() },
                { DayOfWeek.Tuesday, new DayMenu() },
                { DayOfWeek.Wednesday, new DayMenu() },
                { DayOfWeek.Thursday, new DayMenu() },
                { DayOfWeek.Friday, new DayMenu() }
            };
        }
    }
}
