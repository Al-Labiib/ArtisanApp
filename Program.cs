using System;
using System.Collections.Generic;
using System.Linq;
using ArtisanAdo.Net.Enums;
using ARTISANADO.Menus;
using MySql.Data.MySqlClient;
namespace ARTISANADO.Repositories
{
    class Program
    {

        public string connect = "server = localhost;user = root;database = artisanapp;port = 3306;password = Labiib";
        // MySqlConnection connection;
        static void Main(string[] args)
        {
            // new Program().CreateTable();
            MainMenu.WelcomePage();
        }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      

        public void CreateTable()
        {
            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection(connect);
                MySqlCommand command = new MySqlCommand("Create table artisan (id int not null auto_increment primary key, firstName varchar (100), lastName varchar (100), email varchar (100), phoneNumber varchar (30), password varchar (30), dob varchar (100), gender varchar (100), address varchar (100), nextOfKin varchar (100), jobs varchar (100), checkBooking varchar(100), rate varchar (100), wallet varchar(100))", connection);
                connection.Open();
                command.ExecuteNonQuery();
                System.Console.WriteLine("Table created successfully");
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);  
            }
            finally
            {
                connection.Close();
            }
        }
        // How to use using keyword to connect to the DAtabase
    }
}