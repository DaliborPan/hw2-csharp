using System;
using System.Diagnostics;

namespace MenuScrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Scrapper scrapper = new Scrapper();            
            MenuHandler menuHandler = new MenuHandler() { Scrapper = scrapper };
            menuHandler.Program();
        }
    }
}
