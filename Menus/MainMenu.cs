using System;
using ARTISANADO.Enums;
using ARTISANADO.Models;
using ARTISANADO.Repositories;
namespace ARTISANADO.Menus
{
    public static class MainMenu
    {
        static StaffMenu staffMenu = new StaffMenu();
        static CustomerMenu customerMenu = new CustomerMenu();
        static ArtisanMenu artisanMenu = new ArtisanMenu();


        public static void Menu()
        {
            bool exit = false;
            while (!exit)
            {
                WelcomePage();

            }
        }

        public static void WelcomePage()
        {
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine(">>>>>>>>>>> WELCOME TO CLH  ARTISAN APP >>>>>>>>>>");
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");


            Console.WriteLine("Enter 1 to go to Staff Menu:");
            Console.WriteLine("Enter 2 to go to Customer Menu:");
            Console.WriteLine("Enter 3 to go to Artisan Menu: ");
            int op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1:
                    staffMenu.StaffOptionMenu();
                    break;
                case 2:
                    customerMenu.CustomerOptionMenu();
                    break;
                case 3:
                    artisanMenu.ArtisanOptionMenu();
                    break;
            }
        }
    }
}