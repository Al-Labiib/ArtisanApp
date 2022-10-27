using System;
using ARTISANADO.Enums;
using ArtisanAdo.Net.Enums;
using ARTISANADO.Models;
using ARTISANADO.Repositories;
namespace ARTISANADO.Menus
{
    public class StaffMenu
    {
        StaffRepo staffRepo = new StaffRepo();
        ArtisanRepo artisanRepo = new ArtisanRepo();
        ServiceRepo serviceRepo = new ServiceRepo();
        // Artisan artisan = new Artisan();

        public void StaffOptionMenu()
        {
            Console.WriteLine("Enter 1 to login:");
            Console.WriteLine("Enter 0 to go back to Main Menu:");
            int option;
            while (int.TryParse(Console.ReadLine(), out option))
            {
                switch (option)
                {
                    case 1:
                        Login();
                        break;

                    case 0:
                        MainMenu.WelcomePage();
                        return;
                }
            }
            Console.WriteLine("Wrong Input. Try again");

        }
        public void Login()
        {
            Console.WriteLine("Enter your email");
            string email = Console.ReadLine();
            Console.WriteLine("Enter your password");
            string password = Console.ReadLine();
            staffRepo.Login(email, password);
            var ObjectStaff = staffRepo.GetStaff(email);
            if (ObjectStaff != null && email == "labiibola@gmail.com")
            {
                PrintSubMenu();
            }
            else
            {
                System.Console.WriteLine("Invalid input.Try again!");
            }
        }
        public void PrintSubMenu()
        {
            Console.WriteLine("Enter 1 to add new staff:");
            Console.WriteLine("Enter 2 to add new Artisans:");
            Console.WriteLine("Enter 0 to go back to main menu:");
            int option;
            while (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Invalid input. Try again");
            }
            switch (option)
            {
                case 1:
                    AddNewStaff();
                    break;
                case 2:
                    AddNewArtisans();
                    break;
                case 0:
                    MainMenu.WelcomePage();
                    break;
            }

        }

        public void AddNewStaff()
        {
            Console.WriteLine("Enter Staff First Name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Staff Last Name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Staff Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Staff Date Of Birth : yyyy-mm-dd");
            DateTime dateOfBirth;
            while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
            {
                Console.WriteLine("Invalid input. Try again");
            }
            Console.WriteLine("Enter Staff Gender:");
            Console.WriteLine("Enter 1 for Male");
            Console.WriteLine("Enter 2 for Female");
            Console.WriteLine("Enter 3 for Rather Not Say");
            Gender gender;
            while (!Gender.TryParse(Console.ReadLine(), out gender))
            {
                Console.WriteLine("Invalid input. Try again");
            }
            Console.WriteLine("Enter Staff Address: ");
            string address = Console.ReadLine();
            Console.WriteLine("Enter Staff Phone Number:");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter staff  Password:");
            string password = Console.ReadLine();
            Console.WriteLine("Enter staff Next of Kin");
            string nextOfKin = Console.ReadLine();
            Console.WriteLine("Enter Role 1. for accountant 2. for monitor");
            int role;
            while (!int.TryParse(Console.ReadLine(), out role))
            {
                Console.WriteLine("Invalid input, Try again");
            }
            staffRepo.AddNewStaff(firstName, lastName, email, dateOfBirth, gender, address, phoneNumber, password, nextOfKin, (Role)role);

            Console.WriteLine("Congratulations! you have successfully added a new staff");
            Console.WriteLine("Enter 1 to another staffs");
            Console.WriteLine("Enter 2 to add new artisans");
            Console.WriteLine("Enter 0 to go back to MainMenu");
            int option;
            while (!int.TryParse(Console.ReadLine(), out option))
            {
                System.Console.WriteLine("Wrong input.Try again!");
            }
            if (option == 1)
            {
                AddNewStaff();
            }
            else if (option == 2)
            {
                AddNewArtisans();
            }
            else if (option == 0)
            {
                MainMenu.WelcomePage();
            }
        }

        public void AddNewArtisans()
        {
            Console.WriteLine("Enter Artisan First Name:");
            string fName = Console.ReadLine();
            Console.WriteLine("Enter Artisan Last Name:");
            string lName = Console.ReadLine();
            Console.WriteLine("Enter Artisan Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Artisan PhoneNumer");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Artisan Password");
            string password = Console.ReadLine();
            Console.WriteLine("Enter Artisan Date Of Birth yyyy-mm-dd:");
            DateTime dob;
            while (!DateTime.TryParse(Console.ReadLine(), out dob))
            {
                Console.WriteLine("Invalid input. Try again");
            }
            Console.WriteLine("Enter Artisan Gender:");
            Console.WriteLine("Enter 1 for Male");
            Console.WriteLine("Enter 2 for Female");
            Console.WriteLine("Enter 3 for Rather Not Say");
            Gender gender;

            while (!Gender.TryParse(Console.ReadLine(), out gender))
            {
                Console.WriteLine("Invalid input. Try again");
            }
            Console.WriteLine("Enter Artisan  Address: ");
            string address = Console.ReadLine();
            Console.WriteLine("Enter Artisan Next of Kin");
            string nextOfKin = Console.ReadLine();
            Console.WriteLine("Enter Job:");
            string jobName = Console.ReadLine();
            Console.WriteLine("Enter Artisan Rate:");
            decimal rate = decimal.Parse(Console.ReadLine());
            staffRepo.AddNewArtisan(fName, lName, email, dob, gender, address, phoneNumber, password, nextOfKin,jobName, rate);
            Console.WriteLine("Congratulations! you have successfully added a new artisan");
            System.Console.WriteLine("Enter 1 to add new artisans");
            System.Console.WriteLine("Enter 2 to add new staffs");
            System.Console.WriteLine("Enter 0 to go back to main menu");
            int option;
            while (!int.TryParse(Console.ReadLine(), out option))
            {
                System.Console.WriteLine("Wrong input. Try again!");
            }
            switch (option)
            {
                case 1:
                    AddNewArtisans();
                    break;
                case 2:
                    AddNewStaff();
                    break;
                case 3:
                    MainMenu.WelcomePage();
                    break;
                default:
                    System.Console.WriteLine("Wrong input. Try again");
                    break;
            }
        }
        public void EditStaff()
        {
            System.Console.WriteLine("Enter 1 to print all staffs");
            System.Console.WriteLine("Enter 2 to find a staff");
            System.Console.WriteLine("Enter 3 to update staff details");
            System.Console.WriteLine("Enter 4 to delete  staff");
            System.Console.WriteLine("Enter 0 to go back");
            bool exit = false;
            while (!exit)
            {
                System.Console.WriteLine("Enter Number");
                int option;
                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    System.Console.WriteLine("Wrong input. Try again!");
                }
                switch (option)
                {
                    case 1:
                        staffRepo.PrintStaff();
                        EditStaff();
                        break;
                    case 2:
                        System.Console.WriteLine("Enter staff email:");
                        string email = Console.ReadLine();
                        staffRepo.Print1Staff(email);
                        EditStaff();
                        break;
                    case 3:
                        System.Console.WriteLine("Enter staff email");
                        string email1 = Console.ReadLine();
                        staffRepo.UpdateStaff(email1);
                        EditStaff();
                        break;
                    case 4:
                        System.Console.WriteLine("Enter staff email:");
                        string email2 = Console.ReadLine();
                        staffRepo.DeleteStaff(email2);
                        EditStaff();
                        break;
                    case 0:
                        EditStaff();
                        break;
                }
            }
        }
    }
}