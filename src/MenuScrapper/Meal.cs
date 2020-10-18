using System;
namespace MenuScrapper
{
    public class Meal
    {
        public string Name { get; set; }
        public int? Price { get; set; } = null;

        public override string ToString()
        {
            return Name + new string('.', 140 - Name.Length) + Price + "Kč";
        }
    }
}
