using System;
using System.Collections;
using ArtisanAdo.Net.Enums;
using ARTISANADO.Enums;
using ARTISANADO.Models;
using MySql.Data.MySqlClient;
namespace ARTISANADO.Repositories
{
    public class ServiceRepo
    {
        public string connect = "server = localhost;user = root;database = artisanapp;port = 3306;password = Labiib";
        CustomerRepo customerRepo = new CustomerRepo();
        StaffRepo staffRepo = new StaffRepo();
        ArtisanRepo artisanRepo = new ArtisanRepo();

        public ServiceRepo()
        {

        }
        public ServiceRepo(CustomerRepo _customerRepo, StaffRepo _staffRepo, ArtisanRepo _artisanRepo)
        {
            customerRepo = _customerRepo;
            staffRepo = _staffRepo;
            artisanRepo = _artisanRepo;
        }
        public void CheckAvailableArtisans(string job, Customer customer)
        {
            CheckBooking checkBooking = CheckBooking.Available;
            var listAvailableArtisans = artisanRepo.ListAvailableArtisans(checkBooking, job);

            foreach (var availableArtisans in listAvailableArtisans)
            {
                Console.WriteLine($"{availableArtisans.Id} | {availableArtisans.FirstName} | {availableArtisans.LastName} | {availableArtisans.Rate}");
            }
            Console.WriteLine("Enter the Id of the Artisan You need:");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid input. Try again");
            }
            var artisan = artisanRepo.GetOneArtisan(id);
            if (artisan != null && artisan.Id == id)
            {
                Console.WriteLine($"Enter 1 to hire {artisan.FirstName} {artisan.LastName} for a {artisan.Jobs} Job.");
                int option;
                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    System.Console.WriteLine("Wrong input.Try again!");
                }

                if (option == 1)
                {
                    CreateService(artisan, customer);
                }
                else
                {
                    Console.WriteLine("Wrong input. Try again!");
                }

            }

        }
        public void CreateService(Artisan artisan, Customer customer)
        {
            string ServiceId = $"SER{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 7).ToUpper()}";
            DateTime dateOfService = DateTime.Now;
            int ArtisanId = artisan.Id;
            string CustomerId = customer.CustomerId;
            string Job = artisan.Jobs;
            decimal Price = artisan.Rate;
            decimal charges = 7;
            if (customer.Wallet >= Price + charges)
            {
                customer.Wallet = customer.Wallet - (Price + charges);
                artisan.Wallet += Price;
                var sql = $"Update customer set Wallet = {customer.Wallet} where email = {customer.Email}";
                var sql2 = $"Update artisan set Wallet = {artisan.Wallet} where email = {artisan.Email}";
                var query = $"insert into service (ServiceId, dateOfService, ArtisanId, CustomerId, Job, Price) values ({ServiceId},{dateOfService},{ArtisanId},{CustomerId},{Job},{Price})";
                MySqlConnection connection = null;
                connection = new MySqlConnection(connect);
                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlCommand command2 = new MySqlCommand(sql2, connection);
                MySqlCommand command3 = new MySqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                command2.ExecuteNonQuery();
                command3.ExecuteNonQuery();
                Console.WriteLine($"Your Service is successful and your account has been debited with #{Price}");
                connection.Close();
            }
        }
    }
}