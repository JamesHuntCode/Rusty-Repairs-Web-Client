using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RustyRepairsWebClient
{
    public class ProgramServices
    {
        // ***** EDIT THESE PATHS - FOR DEBUGGING ONLY *****
        private string customerFile = @"~\JSONData\customers.json";
        private string staffFile = @"~\JSONData\staff.json";
        private string currentCustomer = @"~\JSONData\currentcustomer.json";

        public ProgramServices()
        {

        }

        // Method to see if login details are correct 
        public bool LoginDetailsCorrect(string email, string password)
        {
            List<Customer> customers = this.GetCustomerData();

            for (int i = 0; i < customers.Count; i++)
            {
                Customer currentCustomer = customers[i];

                if ((email == currentCustomer.EmailAddress) && (password == currentCustomer.Password))
                {
                    return true;
                }
            }

            return false;
        }

        // Method to get all customer data from customers.json
        public List<Customer> GetCustomerData()
        {
            List<Customer> customers = new List<Customer>();

            using (StreamReader SR = new StreamReader(System.Web.Hosting.HostingEnvironment.MapPath(this.customerFile)))
            {
                string json = SR.ReadToEnd();
                customers = JsonConvert.DeserializeObject<List<Customer>>(json);
            }

            return customers;
        }

        // Method to get all customer bookings from customers.json
        public List<Booking> GetCustomerBookingData()
        {
            List<Booking> bookings = new List<Booking>();
            List<Customer> customers = this.GetCustomerData();

            for (int i = 0; i < customers.Count; i++)
            {
                Customer currentCustomer = customers[i];

                for (int j = 0; j < currentCustomer.Bookings.Count; j++)
                {
                    bookings.Add(currentCustomer.Bookings[j]);
                }
            }

            return bookings;
        }

        // Method to get all staff data from staff.json
        public List<Staff> GetStaffData()
        {
            List<Staff> staff = new List<Staff>();

            using (StreamReader SR = new StreamReader(System.Web.Hosting.HostingEnvironment.MapPath(this.staffFile)))
            {
                string json = SR.ReadToEnd();
                staff = JsonConvert.DeserializeObject<List<Staff>>(json);
            }

            return staff;
        }

        // Method to see if customer has input valid details
        public bool DetailsAreValid(string data)
        {
            string[] dataPoints = data.Split(';');

            // Check name length
            if ((dataPoints[0].Length < 3) || (dataPoints[1].Length < 3))
            {
                return false;
            }

            // Check email configuration
            if (!(dataPoints[2].Contains("@") && !(dataPoints[2].Contains(".") && !(dataPoints[2].Length > 5))))
            {
                return false;
            }

            // Check password
            if (dataPoints[3].Length < 4)
            {
                return false;
            }

            return true;
        }

        public int GetNewCustomerID()
        {
            int newID = 0;

            List<Customer> allCustomers = this.GetCustomerData();

            newID = allCustomers.Count + 1;

            return newID;
        }

        // Method to see if customer account already exists
        public bool AlreadyExists(string data)
        {
            List<Customer> allCustomers = this.GetCustomerData();

            string email = data.Split(';')[2];

            for (int i = 0; i < allCustomers.Count; i++)
            {
                Customer currentCustomer = allCustomers[i];

                if (email == currentCustomer.EmailAddress)
                {
                    return true;
                }
            }

            return false;
        }

        // Method to elicit all data from currentcustomer.json
        public Customer GetCurrentCustomerData()
        {
            Customer currentCustomer = new Customer();



            return currentCustomer;
        }

        // Method to wite current customer data to currentcustomer.json
        public void SetCurrentCustomerData(string newCust, Customer existingCust)
        {

        }

        // Method to save all data in memory to .json files
        public void WriteJSON(Customer newCust, Staff newStaff)
        {
            if (newCust != null)
            {
                // Update customer data
                List<Customer> currentCustomers = this.GetCustomerData();
                currentCustomers.Add(newCust);
                string updatedCustomerData = JsonConvert.SerializeObject(currentCustomers, Formatting.Indented);
                File.WriteAllText(System.Web.Hosting.HostingEnvironment.MapPath(this.customerFile), updatedCustomerData);
            }
            else
            {
                // Update staff data
                List<Staff> currentStaff = this.GetStaffData();
                currentStaff.Add(newStaff);
                string updatedCustomerData = JsonConvert.SerializeObject(currentStaff, Formatting.Indented);
                File.WriteAllText(System.Web.Hosting.HostingEnvironment.MapPath(this.customerFile), updatedCustomerData);
            }
        }
    }
}