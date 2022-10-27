using System;
using ArtisanAdo.Net.Enums;
using ARTISANADO.Models;
namespace ARTISANADO.Enums
{
    public class Customer : Person
    {
        public decimal Wallet { get; set; }
        public string CustomerId { get; set; }

        public Customer(int id, string firstName, string lastName, string email, string phoneNumber, string password, DateTime dob, Gender gender, string address, string nextOfKin) : base(firstName, lastName, email, phoneNumber, password, dob, gender, address, nextOfKin, id)
        {
            Wallet = 00.00m;
            CustomerId = $"ST{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 5).ToUpper()}";

        }
        
        public Customer(string firstName, string lastName, string email, string phoneNumber, string password, DateTime dob, Gender gender, string address, string nextOfKin) : base(firstName, lastName, email, phoneNumber, password, dob, gender, address, nextOfKin)
        {
            
        }
    }
}