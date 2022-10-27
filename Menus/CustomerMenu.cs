using System;
using ArtisanAdo.Net.Enums;
using ARTISANADO.Enums;
using ARTISANADO.Models;
using ARTISANADO.Repositories;
namespace ARTISANADO.Menus
{
    public class CustomerMenu
    {
        CustomerRepo customerRepo = new CustomerRepo();
        StaffRepo staffRepo = new StaffRepo();
        ServiceRepo serviceRepo = new ServiceRepo();

        // Customer customer = new Customer();


        public void CustomerOptionMenu()
        {
            Console.WriteLine("1. To login");
            Console.WriteLine("2. To Sign up");
            Console.WriteLine("0. To go back to Main Menu");
            int option;
            while (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Invalid input, Try again.");
            }
            switch (option)
            {
                case 1:
                    Login();
                    break;
                case 2:
                    Register();
                    break;
                case 0:
                    MainMenu.WelcomePage();
                    break;
                    return;
            }
        }


        public void Login()
        {
            Console.WriteLine("Enter Your Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Your Password:");
            string password = Console.ReadLine();
            var customer = customerRepo.Login(email, password);
            if (customer != null)
            {
                // System.Console.WriteLine("if is working");
                AfterCustomerlogin(customer);
            }
            else
            {
                Console.WriteLine("Invalid Email or Password");

            }
        }


            public void AfterCustomerlogin(Customer customer)
            {
                Console.WriteLine("Enter 1 to check available artisans");
                Console.WriteLine("Enter 2 to check your wallet balance");
                Console.WriteLine("Enter 3 to Fund your wallet");
                Console.WriteLine("Enter 0 to go back to main menu");
                int option;
                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Wrong input! Try again.");
                }
                switch (option)
                {
                    case 1:
                    System.Console.WriteLine("Enter job:");
                    string job = Console.ReadLine();
                        serviceRepo.CheckAvailableArtisans(job, customer);
                        break;
                    case 2:
                        customerRepo.CheckWalletBalance(customer);
                        break;
                    case 3:
                        customerRepo.FundWallet(customer);
                        break;
                    case 0:
                        MainMenu.WelcomePage();
                        break;

                }
            }
            // public void CheckAvailableArtisans()
            // {
            //     serviceRepo.CheckAvailableArtisans(job, customer)
            // }
        public void Register()
        {
            Console.WriteLine("Enter your First Name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter your Last Name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Your Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Your Date of Birth: yyyy-mm-dd");
            DateTime dob;
            while (!DateTime.TryParse(Console.ReadLine(), out dob))
            {
                Console.WriteLine("Wrong Input. Try again");
            }
            Console.WriteLine("Enter your Gender:");
            Console.WriteLine("Enter 1 for Male");
            Console.WriteLine("Enter 2 for Female");
            Console.WriteLine("Enter 3 for Rather Not Say");
            Gender gender;
            while (!Gender.TryParse(Console.ReadLine(), out gender))
            {
                Console.WriteLine("Wrong Input. Try again");
            }
            Console.WriteLine("Enter Your Address:");
            string address = Console.ReadLine();
            Console.WriteLine("Enter Your Phone Number:");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Your PassWord:");
            string password = Console.ReadLine();
            Console.WriteLine("Enter Your Next of kin :");
            string nextOfKin = Console.ReadLine();
            customerRepo.Register(firstName, lastName, email, phoneNumber, password, dob, (Gender)gender, address, nextOfKin);
            Console.WriteLine("You have successfully registered an account");
            Console.WriteLine("Enter 1 to Login");
            Console.WriteLine("Enter 0 to go back to main menu");
            int option;
            while (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Invalid input, Try again.");
            }
            switch (option)
            {
                case 1:
                    Login();
                    break;
                case 2:
                    MainMenu.WelcomePage();
                    break;
            }
        }
    }
}