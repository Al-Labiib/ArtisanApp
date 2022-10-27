using System;
using System.Collections;
using ArtisanAdo.Net.Enums;
using ARTISANADO.Enums;
using ARTISANADO.Models;
using MySql.Data.MySqlClient;

namespace ARTISANADO.Repositories
{
    public class StaffRepo
    {
        public string connect = "server = localhost;user = root;database = artisanapp;port = 3306;password = Labiib";
        public decimal Wallet { get; set; }
        public List<Service> services = new List<Service>();
        int count = 1;
        public StaffRepo()
        {

        }
        public StaffRepo(string firstName, string lastName, string email, string phoneNumber, string password, DateTime dob, Gender gender, string address, string nextOfKin, Role role)
        {
            // var staff = new Staff( Boss", "Oga", "boss@gmail.com", "08033660368", "Password", DateTime.Parse("1960-07-20"), Gender.Rather_Not_Say, "Abeokuta", "Bosswife");
            Staff staff = new Staff(firstName, lastName, email, phoneNumber, password, dob, gender, address, nextOfKin, role);
            MySqlConnection connection = null;
            connection = new MySqlConnection(connect);
            var query = $"INSERT INTO staff (firstName, lastName, email, phoneNumber, password, dob, gender, address, nextOfKin) VALUES ('{staff.FirstName} {staff.LastName} {staff.Email} {staff.PhoneNumber} {staff.Password} {staff.Dob} {staff.Gender} {staff.Address} {staff.NextOfKin}')";
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void AddNewStaff(string firstName, string lastName, string email, DateTime dateOfBirth, Gender gender, string address, string phoneNumber, string password, string nextOfKin, Role role)
        {
            // var staff = new Staff(firstName, lastName, email, phoneNumber, password, dateOfBirth, gender, address, nextOfKin);
            Staff staffs = new Staff(firstName, lastName, email, phoneNumber, password, dateOfBirth, gender, address, nextOfKin, role);
            MySqlConnection connection = null;
            connection = new MySqlConnection(connect);
            var query = $"INSERT INTO staff (firstName, lastName, email, phoneNumber, password, dob, gender, address, nextOfKin, role) VALUES ('{staffs.FirstName}','{staffs.LastName}','{staffs.Email}','{staffs.PhoneNumber}','{staffs.Password}','{staffs.Dob}','{staffs.Gender}','{staffs.Address}','{staffs.NextOfKin}','{staffs.Role}')";
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            System.Console.WriteLine("You have successfully added a new staff");
        }
        public void AddNewArtisan(string firstName, string lastName, string email, DateTime dob, Gender gender, string address, string phoneNumber, string password, string nextOfKin, string jobs, decimal rate)
        {
            CheckBooking checkBooking = CheckBooking.Available;
            Artisan artisan = new Artisan(firstName, lastName, email, phoneNumber, password, dob, gender, address, nextOfKin, jobs, checkBooking, rate);
            MySqlConnection connection = null;
            var query = $"INSERT INTO `artisan` (firstName, lastName, email, phoneNumber, password, dob, gender, address, nextOfKin, jobs, checkBooking, rate) VALUE ('{artisan.FirstName}','{artisan.LastName}','{artisan.Email}','{artisan.PhoneNumber}','{artisan.Password}','{artisan.Dob}','{artisan.Gender}','{artisan.Address}','{artisan.NextOfKin}','{artisan.Jobs}', '{artisan.CheckBooking}', '{artisan.Rate}')";
            try
            {
                connection = new MySqlConnection(connect);
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                //System.Console.WriteLine(rowAffected);
                System.Console.WriteLine("You have successfully added a new artisan");
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public Staff Login(string email, string password)
        {
            var staff = GetStaff(email);
            if (staff != null && staff.Password == password)
            {
                return staff;
            }
            return null;
        }
        public Staff GetStaff(string email)
        {
            Staff staff = null;
            MySqlConnection connection = null;
            connection = new MySqlConnection(connect);
            var sql = "select * from staff where email = '" + email + "'";
            MySqlCommand command = new MySqlCommand(sql, connection);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
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
                Role Role = (Role)Enum.Parse(typeof(Role), $"{reader["Role"]}");
                staff = new Staff(FirstName, LastName, Email, PhoneNumber, Password, Dob, Gender, Address, NextOfKin, Role);
            }
            connection.Close();
            return staff;
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
                connection.Close();
                return artisan;
            }
            else
            {
                return null;
            }
        }
        public List<Staff> ListAllStaffs()
        {
            List<Staff> staffs = new List<Staff>();
            MySqlConnection connection = null;
            connection = new MySqlConnection(connect);
            var sql = "select * from staff";
            var query = $"select count(*) from staff";
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
                    Role Role = (Role)Enum.Parse(typeof(Role), $"{reader["Role"]}");
                    var staff = new Staff(FirstName, LastName, Email, PhoneNumber, Password, Dob, Gender, Address, NextOfKin, Role);
                    staffs.Add(staff);
                }
                return staffs;
            }
            else
            {
                return null;
            }
        }
        public Staff PrintStaff()
        {
            var staffs = ListAllStaffs();
            foreach (var staff in staffs)
            {
                if (staff != null)
                {
                    System.Console.WriteLine($"{staff.FirstName} {staff.LastName} {staff.Email} {staff.PhoneNumber} {staff.Password} {staff.Dob} {staff.Gender} {staff.Gender} {staff.Address} {staff.NextOfKin} {staff.Role}");
                }
                else
                {
                    System.Console.WriteLine("No Staff Found");
                }
            }
            return null;
        }
        public Staff Print1Staff(string email)
        {
            var staff = GetStaff(email);
            if (staff != null)
            {
                System.Console.WriteLine($"{staff.FirstName} {staff.LastName} {staff.Email} {staff.PhoneNumber} {staff.Password} {staff.Dob} {staff.Gender} {staff.Gender} {staff.Address} {staff.NextOfKin} {staff.Role}");
            }
            return null;
        }
        public Staff DeleteStaff(string email3)
        {
            string email = email3;
            var staff = GetStaff(email);
            if (staff != null)
            {
                System.Console.WriteLine($"You are about to delete a profile {staff.FirstName} {staff.LastName} \n Enter 1 to continue or 0 to cancel");
                int option;
                System.Console.WriteLine("Enter Number:");
                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    System.Console.WriteLine("Wrong input. Enter 1 or 0");
                }
                if (option == 1)
                {
                    MySqlConnection connection = null;
                    connection = new MySqlConnection(connect);
                    MySqlCommand command = new MySqlCommand($"DELETE FROM 'staff' WHERE Email = '{staff.Email}'.connection");
                    connection.Open();
                    command.ExecuteNonQuery();
                    System.Console.WriteLine($"{staff.FirstName} {staff.LastName} has been successfully removed as staff");
                    connection.Close();
                }
            }
            return null;
        }
        public void UpdateStaff(string email)
        {
            var staff = GetStaff(email);
            if (staff != null && staff.Email == email)
            {
                System.Console.WriteLine("Enter FirstName:");
                string FirstName = Console.ReadLine();
                System.Console.WriteLine("Enter your Last Name:");
                string LastName = Console.ReadLine();
                System.Console.WriteLine("Enter your Email:");
                string Email = Console.ReadLine();
                System.Console.WriteLine("Enter PhoneNumber:");
                string PhoneNumber = Console.ReadLine();
                System.Console.WriteLine("Enter a new password");
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
                System.Console.WriteLine("Enter your Next Of Kin:");
                string NextOfKin = Console.ReadLine();
                System.Console.WriteLine("Enter Role:");
                int Role;
                while (!int.TryParse(Console.ReadLine(), out Role) && Role > 3 || Role < 1)
                {
                    System.Console.WriteLine("Incorrect Input, Try again!");
                }
                MySqlConnection connection = null;
                connection = new MySqlConnection(connect);
                MySqlCommand command = new MySqlCommand($"Update staff set firstName = '{FirstName}', '{LastName}', '{Email}', '{PhoneNumber}','{Password}','{Dob}', '{Gender}', '{Address}', '{NextOfKin}', '{Role}'where email = {email}", connection);
                connection.Open();
                command.ExecuteNonQuery();
                System.Console.WriteLine("Staff Details Updated Successfully");
                connection.Close();
            }
            else
            {
                System.Console.WriteLine("Invalid email or password");
            }
        }
        public void UpdateArtisans(string email)
        {
            var artisan = GetArtisan(email);
            if (artisan != null && artisan.Email == email)
            {
                System.Console.WriteLine("Enter FirstName:");
                string FirstName = Console.ReadLine();
                System.Console.WriteLine("Enter your Last Name:");
                string LastName = Console.ReadLine();
                System.Console.WriteLine("Enter your Email:");
                string Email = Console.ReadLine();
                System.Console.WriteLine("Enter PhoneNumber:");
                string PhoneNumber = Console.ReadLine();
                System.Console.WriteLine("Enter a new password");
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
                System.Console.WriteLine("Enter your Next Of Kin:");
                string NextOfKin = Console.ReadLine();
                MySqlConnection connection = null;
                System.Console.WriteLine("Enter Jobs:");
                string Jobs = Console.ReadLine();
                System.Console.WriteLine("Enter Artisan Rate: ");
                decimal Rate = decimal.Parse(Console.ReadLine());
                MySqlCommand command = new MySqlCommand($"Update artisan set firstName = '{FirstName}', '{LastName}', '{Email}', '{PhoneNumber}','{Password}','{Dob}', '{Gender}', '{Address}','{Jobs}','{NextOfKin}', '{Rate}' where email = {email}", connection);
                connection.Open();
                command.ExecuteNonQuery();
                System.Console.WriteLine("Artisan Details Updated Successfully");
                connection.Close();
            }
            else
            {
                System.Console.WriteLine("Invalid email or password");
            }
        }
    }
}
