using System;
using System.Collections;
using ArtisanAdo.Net.Enums;
namespace ARTISANADO.Models
{
    public class Artisan : Person
    {
        public string ArtisanNumber { get; set; }
        public decimal Wallet { get; set; }
        public decimal Rate { get; set; }
        public string Jobs { get; set; }
        public CheckBooking CheckBooking { get; set; }
        public Artisan(int id, string firstName, string lastName, string email, string phoneNumber, string password, DateTime dob, Gender gender, string address, string nextOfKin, string jobs, CheckBooking checkBooking, decimal rate) : base(firstName, lastName, email, phoneNumber, password, dob, gender, address, nextOfKin, id)
        {
            CheckBooking = checkBooking;
            Wallet = 00.00m;
            ArtisanNumber = $"CU{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 5).ToUpper()}";
        }
        public Artisan(string firstName, string lastName, string email, string phoneNumber, string password, DateTime dob, Gender gender, string address, string nextOfKin, string Jobs, CheckBooking checkBooking, decimal rate) : base(firstName, lastName, email, phoneNumber, password, dob, gender, address, nextOfKin)
        {
            CheckBooking = checkBooking;
            Wallet = 00.00m;
            ArtisanNumber = $"CU{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 5).ToUpper()}";
        }
    }
}