using System;
using ArtisanAdo.Net.Enums;
namespace ARTISANADO.Models
{
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public DateTime Dob { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public string NextOfKin { get; set; }
        public int Id { get; set; }

        public Person(string firstName, string lastName, string email, string phoneNumber, string password, DateTime dob, Gender gender, string address, string nextOfKin, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
            Dob = dob;
            Gender = gender;
            Address = address;
            NextOfKin = nextOfKin;
            Id = id;
        }
        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }

        public Person(string firstName, string lastName, string email, string phoneNumber, string password, DateTime dob, Gender gender, string address, string nextOfKin)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
            Dob = dob;
            Gender = gender;
            Address = address;
            NextOfKin = nextOfKin;
        }

    }
}