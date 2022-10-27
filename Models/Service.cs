using System;
using ARTISANADO.Enums;
namespace ARTISANADO.Models
{
    public class Service
    {
        public int id { get; set; }
        public string ArtisanJob { get; set; }
        public string ServiceReference { get; set; }
        public decimal Price { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }


        // public Service(int id, string customerName, int customerId)
        // {
        //     id = id;
        //     ServiceReference = ServiceReference = $"{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 6).ToUpper()}";
        //     CustomerName = customerName;
        //     CustomerId = CustomerId;
        // }

        public Service(string artisanJob, decimal price)
        {
            ArtisanJob = artisanJob;
            Price = price;
        }
    }
}