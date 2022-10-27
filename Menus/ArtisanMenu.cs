using System;
using ARTISANADO.Enums;
using ARTISANADO.Models;
using ARTISANADO.Repositories;
namespace ARTISANADO.Menus
{
    public class ArtisanMenu
    {
        ArtisanRepo artisanRepo = new ArtisanRepo();
        public void ArtisanOptionMenu()
        {
            Console.WriteLine("Enter 1 to login:");
            Console.WriteLine("Enter 0 to go back to Main Menu:");
            int option;
            while (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Wrong Input. Try again");

            }
            switch (option)
            {
                case 1:
                    Login();
                    break;
                    break;
                case 0:
                    MainMenu.WelcomePage();
                    return;
            }
        }
        public void Login()
        {
            Console.WriteLine("Enter your email");
            string email = Console.ReadLine();
            Console.WriteLine("Enter your password");
            string password = Console.ReadLine();
            artisanRepo.Login(email, password);
            var ObjectArtisan = artisanRepo.GetArtisan(email);
            if (ObjectArtisan != null)
                Console.WriteLine("You have successfully login to your account");
            else
            {
                System.Console.WriteLine("Invalid input");
            }
        }

        public void CheckWalletBalance(string email, Artisan artisan)
        {
            Console.WriteLine("Enter 1 to check your wallet balance");
            int option = int.Parse(Console.ReadLine());
            System.Console.WriteLine($"Your wallet balance is {artisanRepo.Wallet} ");

            System.Console.WriteLine("Enter 1 to fund your wallet");
            int op;
            while (!int.TryParse(Console.ReadLine(), out op))
            {
                System.Console.WriteLine("Wrong input. Try again");
            }
            if (op == 1)
            {
                artisanRepo.CheckWalletBalance(artisan);
            }
        }




    }
}