using System;
using System.Collections;
using System.Linq;
using ArtisanAdo.Net.Enums;
using ARTISANADO.Enums;
namespace ARTISANADO.Models
{
    public class Staff : Person
    {
        public string StaffNo { get; set; }
        public Role Role { get; set; }
        public decimal Wallet { get; set; }

        public Staff(int id, string firstName, string lastName, string email, string phoneNumber, string password, DateTime dob, Gender gender, string address, string nextOfKin, Role role) : base(firstName, lastName, email, phoneNumber, password, dob, gender, address, nextOfKin, id)
        {
            Wallet = 100000.00m;
            StaffNo = $"ST{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 5).ToUpper()}";
            Role = Role;
        }
        public Staff(string firstName, string lastName, string email, string phoneNumber, string password, DateTime dob, Gender gender, string address, string nextOfKin, Role role) : base(firstName, lastName, email, phoneNumber, password, dob, gender, address, nextOfKin)
        {
            Wallet = 100000.00m;
            StaffNo = $"ST{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 5).ToUpper()}";
            Role = Role;
        }
    }
}