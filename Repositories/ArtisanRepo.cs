using System;
using System.Collections;
using ArtisanAdo.Net.Enums;
using ARTISANADO.Models;
using ARTISANADO.Menus;
using MySql.Data.MySqlClient;
namespace ARTISANADO.Repositories
{
    public class ArtisanRepo
    {
        public string connect = "server = localhost;user = root;database = artisanapp;port = 3306;password = Labiib";
        public int count = 1;
        public int myIndex = 0;
        public decimal Wallet { get; set; }

        public Artisan Login(string email, string password)
        {
            var artisan = GetArtisan(email);
            if (artisan != null)
            {
                return artisan;
            }
            return null;
        }

        public Artisan GetArtisan(string email)
        {
            Artisan artisan = null;
            MySqlConnection connection = null;
            connection = new MySqlConnection(connect);
            var sql = "select * from artisan where email = '" + email + "'";
            MySqlCommand command = new MySqlCommand(sql, connection);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int id = int.Parse($"{reader["Id"]}");
                string FirstName = $"{reader["FirstName"]}";
                string LastName = $"{reader["LastName"]}";
                string Email = $"{reader["Email"]}";
                string PhoneNumber = $"{reader["PhoneNumber"]}";
                string Password = $"{reader["Password"]}";
                DateTime Dob = DateTime.Parse($"{reader["Dob"]}");
                Gender Gender = (Gender)Enum.Parse(typeof(Gender), $"{reader["Gender"]}");
                string Address = $"{reader["Address"]}";
                string NextOfKin = $"{reader["NextOfKin"]}";
                string Jobs = $"{reader["Jobs"]}";
                decimal Rate = decimal.Parse($"{reader["Rate"]}");
                CheckBooking CheckBooking = (CheckBooking)Enum.Parse(typeof(CheckBooking), $"{reader["CheckBooking"]}");
                artisan = new Artisan(id, FirstName, LastName, Email, PhoneNumber, Password, Dob, Gender, Address, NextOfKin, Jobs, CheckBooking, Rate);
                connection.Close();
                return artisan;
            }
            else
            {
                return null;
            }
        }
        public Artisan GetOneArtisan(int id)
        {
            Artisan artisan = null;
            MySqlConnection connection = null;
            connection = new MySqlConnection(connect);
            var sql = "select * from artisan where Id = '" + id + "'";
            MySqlCommand command = new MySqlCommand(sql, connection);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                // int id = int.Parse($"{reader["Id"]}");
                string FirstName = $"{reader["FirstName"]}";
                string LastName = $"{reader["LastName"]}";
                string Email = $"{reader["Email"]}";
                string PhoneNumber = $"{reader["PhoneNumber"]}";
                string Password = $"{reader["Password"]}";
                DateTime Dob = DateTime.Parse($"{reader["Dob"]}");
                Gender Gender = (Gender)Enum.Parse(typeof(Gender), $"{reader["Gender"]}");
                string Address = $"{reader["Address"]}";
                string NextOfKin = $"{reader["NextOfKin"]}";
                string Jobs = $"{reader["NextOfKin"]}";
                decimal Rate = decimal.Parse($"{reader["Rate"]}");
                CheckBooking CheckBooking = (CheckBooking)Enum.Parse(typeof(CheckBooking), $"{reader["CheckBooking"]}");
                artisan = new Artisan(FirstName, LastName, Email, PhoneNumber, Password, Dob, Gender, Address, NextOfKin, Jobs, CheckBooking, Rate);
                connection.Close();
                return artisan;
            }
            else
            {
                return null;
            }
        }
        public List<Artisan> ListAllArtisans()
        {
            List<Artisan> artisans = new List<Artisan>();
            MySqlConnection connection = null;
            connection = new MySqlConnection(connect);
            var sql = "select * from artisan";
            var query = $"select count(*) from artisan";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlCommand countCommand = new MySqlCommand(query, connection);
            int count = 0;
            connection.Open();
            using (countCommand)
            {
                count = Convert.ToInt32(countCommand.ExecuteScalar());
            }
            MySqlDataReader reader = command.ExecuteReader();
            if (count != 0)
            {
                for (var i = 0; i < count; i++)
                {
                    reader.Read();
                    int id = int.Parse($"{reader["Id"]}");
                    string FirstName = $"{reader["FirstName"]}";
                    string LastName = $"{reader["LastName"]}";
                    string Email = $"{reader["Email"]}";
                    string PhoneNumber = $"{reader["PhoneNumber"]}";
                    string Password = $"{reader["Password"]}";
                    DateTime Dob = DateTime.Parse($"{reader["Dob"]}");
                    Gender Gender = (Gender)Enum.Parse(typeof(Gender), $"{reader["Gender"]}");
                    string Address = $"{reader["Address"]}";
                    string NextOfKin = $"{reader["NextOfKin"]}";
                    string Jobs = $"{reader["Jobs"]}";
                    decimal Rate = decimal.Parse($"{reader["Rate"]}");
                    CheckBooking CheckBooking = (CheckBooking)Enum.Parse(typeof(CheckBooking), $"{reader["CheckBooking"]}");
                    var artisan = new Artisan(id, FirstName, LastName, Email, PhoneNumber, Password, Dob, Gender, Address, NextOfKin, Jobs, CheckBooking, Rate);
                    artisans.Add(artisan);
                }
                return artisans;
            }
            else
            {
                return null;
            }
        }

        public List<Artisan> ListAvailableArtisans(CheckBooking check, string job)
        {
            List<Artisan> artisans = new List<Artisan>();
            MySqlConnection connection = null;
            connection = new MySqlConnection(connect);
            var sql = $"select * from `artisan` where `CheckBooking` = '{check}' && `Jobs` = '{job}'";
            var query = $"select count(*) from artisan";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlCommand countCommand = new MySqlCommand(query, connection);
            int count = 0;
            connection.Open();
            using (countCommand)
            {
                count = Convert.ToInt32(countCommand.ExecuteScalar());
            }
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if (count != 0)
            {
                for (var i = 0; i < count; i++)
                {

                    string FirstName = $"{reader["FirstName"]}";
                    string LastName = $"{reader["LastName"]}";
                    string Email = $"{reader["Email"]}";
                    string PhoneNumber = $"{reader["PhoneNumber"]}";
                    string Password = $"{reader["Password"]}";
                    DateTime Dob = DateTime.Parse($"{reader["Dob"]}");
                    Gender Gender = (Gender)Enum.Parse(typeof(Gender), $"{reader["Gender"]}");
                    string Address = $"{reader["Address"]}";
                    string NextOfKin = $"{reader["NextOfKin"]}";
                    string Jobs = $"{reader["Jobs"]}";
                    decimal Rate = decimal.Parse($"{reader["Rate"]}");
                    CheckBooking CheckBooking = (CheckBooking)Enum.Parse(typeof(CheckBooking), $"{reader["CheckBooking"]}");
                    var artisan = new Artisan(FirstName, LastName, Email, PhoneNumber, Password, Dob, Gender, Address, NextOfKin, Jobs, CheckBooking, Rate);
                    if (artisan.CheckBooking == CheckBooking.Available)
                    {
                        artisans.Add(artisan);
                    }
                }
                return artisans;
            }
            else
            {
                return null;
            }
        }

        public void UpdateArtisans(string email)
        {

            var artisan = GetArtisan(email);
            if (artisan != null && artisan.Email == email)
            {
                System.Console.WriteLine("Enter FirstName:");
                string FirstName = Console.ReadLine();
                System.Console.WriteLine("Enter Last Name:");
                string LastName = Console.ReadLine();
                System.Console.WriteLine("Enter Email:");
                string Email = Console.ReadLine();
                System.Console.WriteLine("Enter PhoneNumber:");
                string PhoneNumber = Console.ReadLine();
                System.Console.WriteLine("Enter password");
                string Password = Console.ReadLine();
                System.Console.WriteLine("Enter your date of birth yyyy-mm-dd: ");
                DateTime Dob = DateTime.Parse(Console.ReadLine());
                System.Console.WriteLine("Enter Gender:");
                int Gender;
                while (!int.TryParse(Console.ReadLine(), out Gender) && Gender > 3 || Gender < 1)
                {
                    System.Console.WriteLine("Incorrect Input, Try again!");
                }
                System.Console.WriteLine("Enter Address:");
                string Address = Console.ReadLine();
                System.Console.WriteLine("Enter Next Of Kin:");
                string NextOfKin = Console.ReadLine();
                System.Console.WriteLine("Enter Artisan Job:");
                string Jobs = Console.ReadLine();
                System.Console.WriteLine("Enter artisan Rate:");
                decimal Rate = decimal.Parse(Console.ReadLine());
                MySqlConnection connection = null;
                connection = new MySqlConnection(connect);
                MySqlCommand command = new MySqlCommand($"Update artisan set firstName = '{FirstName}', '{LastName}', '{Email}', '{PhoneNumber}','{Password}','{Dob}', '{Gender}', '{Address}', '{NextOfKin}', '{Jobs}', '{Rate}' where email = {email}", connection);
                connection.Open();
                command.ExecuteNonQuery();
                System.Console.WriteLine("Artisan updated succesfully");
                connection.Close();
            }
            else
            {
                System.Console.WriteLine("Invalid email or password");
            }
        }

        public void FundWallet(Artisan artisan)
        {

            System.Console.WriteLine("Enter amount to fund your wallet");
            decimal amount = decimal.Parse(Console.ReadLine());
            artisan.Wallet += amount;
            var sql = $"Update artisan set Wallet = {artisan.Wallet} where email = {artisan.Email}";
            MySqlConnection connection = null;
            connection = new MySqlConnection(connect);
            MySqlCommand command = new MySqlCommand(sql, connection);
            connection.Open();
            command.ExecuteNonQuery();
            System.Console.WriteLine($"Your Transaction is successful and your account has been credited with {amount}");
            connection.Close();
        }
        public void CheckWalletBalance(Artisan artisan)
        {
            Console.WriteLine($"Your Wallet balance is: {artisan.Wallet}");
        }
        public void CashoutFromWallet(Artisan artisan)
        {
            System.Console.WriteLine("Enter amount to remove from your wallet");
            decimal amount = decimal.Parse(Console.ReadLine());
            artisan.Wallet -= amount;
            var sql = $"Update artisan set Wallet = {artisan.Wallet} where email = {artisan.Email}";
            MySqlConnection connection = null;
            connection = new MySqlConnection(connect);
            MySqlCommand command = new MySqlCommand(sql, connection);
            connection.Open();
            command.ExecuteNonQuery();
            System.Console.WriteLine($"Your Transaction is successful and your account has been debited with {amount}");
            connection.Close();
        }

    }
}

