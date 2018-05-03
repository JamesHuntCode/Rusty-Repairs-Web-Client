using System;
using System.IO;
using System.Collections.Generic;

namespace RustyRepairsWebClient
{
    public class ProgramServices
    {
        private string customerFile = "~/JSONData/customers.json";
        private string staffFile = "~/JSONData/staff.json";

        public ProgramServices()
        {

        }

        // Method to see if login details are correct 
        public bool LoginDetailsCorrect(string email, string password)
        {
            return false;
        }

        // Method to get all customer data from customers.json
        public List<Customer> GetCustomerData()
        {
            List<Customer> customers = new List<Customer>();



            return customers;
        }

        // Method to get all customer bookings from customers.json
        public List<Booking> GetCustomerBookingData()
        {
            List<Booking> bookings = new List<Booking>();



            return bookings;
        }

        // Method to get all staff data from staff.json
        public List<Staff> GetStaffData()
        {
            List<Staff> staff = new List<Staff>();



            return staff;
        }

        // Method to see if customer account already exists
        public bool AlreadyExists(Customer customer)
        {
            return true;
        }

        // Method to save all data in memory to .json files
        public void SaveAllJSONData(List<Customer> customers, List<Staff> staff)
        {

        }
    }
}