﻿using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RustyRepairsWebClient
{
    public class ProgramServices
    {
        // JSON Data file paths
        private string customerFile = @"~\JSONData\customers.json";
        private string staffFile = @"~\JSONData\staff.json";
        private string currentCustomer = @"~\JSONData\currentcustomer.json";
        private string workplan = @"~\JSONData\workplan.json";

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

                if ((email == currentCustomer.EmailAddress) && (password == currentCustomer.Password) && (currentCustomer.HasActiveAccount))
                {
                    return true;
                }
            }

            return false;
        }

        // Method to validate data provided by customer regarding their vehicle
        public bool VehicleDataIsValid(string data)
        {
            string[] breakdown = data.Split(';');

            // Check car make and model
            if ((breakdown[0].Length == 0) || (breakdown[1].Length == 0))
            {
                return false;
            }

            // Check registration data
            if (breakdown[2].Length == 0)
            {
                return false;
            }

            // Check car owner data
            if (breakdown[3].Length < 2)
            {
                return false;
            }

            return true;
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

        // Method used to get all customer data from login details provided by customer
        public Customer GetAllDetails(string details)
        {
            Customer cust = new Customer();

            string[] data = details.Split(';');

            for (int i = 0; i < this.GetCustomerData().Count; i++)
            {
                string custEmail = this.GetCustomerData()[i].EmailAddress;
                string custPassword = this.GetCustomerData()[i].Password;

                if ((data[0] == custEmail) && (data[1] == custPassword))
                {
                    cust = this.GetCustomerData()[i];
                    break;
                }
            }

            return cust;
        }

        // Method to get all customer bookings from customers.json
        public List<Booking> GetCustomerBookingData()
        {
            List<Booking> bookings = new List<Booking>();
            List<Customer> customers = this.GetCustomerData();

            for (int i = 0; i < customers.Count; i++)
            {
                Customer currentCustomer = customers[i];

                if (currentCustomer.Bookings != null)
                {
                    for (int j = 0; j < currentCustomer.Bookings.Count; j++)
                    {
                        bookings.Add(currentCustomer.Bookings[j]);
                    }
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

        // Method to get all workplans from workplan.json
        public List<Workplan> Getworkplans()
        {
            List<Workplan> workplans = new List<Workplan>();

            using (StreamReader SR = new StreamReader(System.Web.Hosting.HostingEnvironment.MapPath(this.workplan)))
            {
                string json = SR.ReadToEnd();
                workplans = JsonConvert.DeserializeObject<List<Workplan>>(json);
            }

            return workplans;
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

        // Method to assign a new customer a new ID
        public int GetNewCustomerID()
        {
            int newID = 0;

            List<Customer> allCustomers = this.GetCustomerData();

            if (allCustomers != null)
            {
                newID = allCustomers.Count + 1;
            }
            else
            {
                newID = 1;
            }

            return newID;
        }

        // Method to assign a new booking a new ID
        public int GetNewBookingID()
        {
            int newID = 0;

            List<Booking> bookings = this.GetCustomerBookingData();

            if (bookings != null)
            {
                newID = bookings.Count + 1;
            }
            else
            {
                newID = 1;
            }

            return newID;
        }

        // Method to assign a new workplan ID
        public int GetNewWorkPlanID()
        {
            int newID = 0;

            List<Workplan> workplans = this.Getworkplans();

            newID = workplans.Count + 1;

            return newID;
        }

        // Method to see if customer account already exists
        public bool AlreadyExists(string data, bool updating)
        {
            List<Customer> allCustomers = this.GetCustomerData();

            string email = data.Split(';')[2];

            if (!updating)
            {
                if (allCustomers != null)
                {
                    for (int i = 0; i < allCustomers.Count; i++)
                    {
                        Customer currentCustomer = allCustomers[i];

                        if (email == currentCustomer.EmailAddress)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                for (int i = 0; i < allCustomers.Count; i++)
                {
                    Customer currentCustomer = allCustomers[i];

                    if ((email == currentCustomer.EmailAddress) && !(this.GetCurrentCustomerData().EmailAddress == currentCustomer.EmailAddress))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        // Method to elicit all data from currentcustomer.json
        public Customer GetCurrentCustomerData()
        {
            Customer currentCustomer = new Customer();
            List<Customer> data = new List<Customer>();

            using (StreamReader SR = new StreamReader(System.Web.Hosting.HostingEnvironment.MapPath(this.currentCustomer)))
            {
                string json = SR.ReadToEnd();
                data = JsonConvert.DeserializeObject<List<Customer>>(json);
            }

            currentCustomer = data[0];

            return currentCustomer;
        }

        // Method to wite current customer data to currentcustomer.json
        public void SetCurrentCustomerData(Customer cust)
        {
            List<Customer> currentCustomer = new List<Customer>();
            currentCustomer.Add(cust);
            string updatedCustomerData = JsonConvert.SerializeObject(currentCustomer, Formatting.Indented);
            File.WriteAllText(System.Web.Hosting.HostingEnvironment.MapPath(this.currentCustomer), updatedCustomerData);
        }

        // Method to update customer data currently in our system
        public void UpdateCustomerData(Customer customer)
        {
            Customer customerToBeChanged = customer;
            List<Customer> customers = this.GetCustomerData();

            for (int i = 0; i < customers.Count; i++)
            {
                Customer currentCustomerInLoop = customers[i];

                if (customerToBeChanged.CustomerID == currentCustomerInLoop.CustomerID)
                {
                    customers.Remove(currentCustomerInLoop);
                    customers.Add(customerToBeChanged);
                    break;
                }
            }

            this.UpdateJSON(customers);
        }

        public void UpdateWorkplans(bool remove, Workplan workplan)
        {
            List<Workplan> workplans = this.Getworkplans();

            if (remove)
            {
                Workplan wp = workplans.Find(w => w.WorkPlanID == workplan.WorkPlanID);
                if (wp == null)
                    return;

                Booking booking = this.GetBookingFromWorkplan(wp);
                booking.Pending = true;
                booking.ManagerApproved = false;
                booking.ManagerDeclined = false;
                this.UpdateBooking("update", booking);
                workplans.Remove(wp);
                this.UpdateWorkplanJSON(workplans);
                return;
            }

            workplans.Add(workplan);

            this.UpdateWorkplanJSON(workplans);
        }

        // Method to allow the garage manager to decline or approve bookings
        public void UpdateBooking(string action, Booking booking, string newProblem="")
        {
            Booking bookingToBeChanged = booking;
            List<Customer> customers = this.GetCustomerData();

            if (action == "approve")
            {
                // Update properties
                bookingToBeChanged.ManagerApproved = true;
                bookingToBeChanged.ManagerDeclined = false;
                bookingToBeChanged.Pending = false;

                // Save JSON data
                for (int i = 0; i < customers.Count; i++)
                {
                    for (int j = 0; j < customers[i].Bookings.Count; j++)
                    {
                        Booking currentBookingInLoop = customers[i].Bookings[j];

                        if (bookingToBeChanged.BookingID == currentBookingInLoop.BookingID)
                        {
                            customers[i].Bookings.Remove(currentBookingInLoop);
                            customers[i].Bookings.Add(bookingToBeChanged);
                            break;
                        }
                    }
                }

                this.UpdateJSON(customers);
            }
            else if(action == "update")
            {
                bookingToBeChanged.ProblemSummary = newProblem;
                // Save JSON data
                for (int i = 0; i < customers.Count; i++)
                {
                    if (customers[i].Bookings == null)
                        continue;

                    for (int j = 0; j < customers[i].Bookings.Count; j++)
                    {
                        Booking currentBookingInLoop = customers[i].Bookings[j];

                        if (bookingToBeChanged.BookingID == currentBookingInLoop.BookingID)
                        {
                            customers[i].Bookings.Remove(currentBookingInLoop);
                            customers[i].Bookings.Add(bookingToBeChanged);
                            break;
                        }
                    }
                }

                this.UpdateJSON(customers);
            }
            else
            {
                // Update properties
                bookingToBeChanged.ManagerApproved = false;
                bookingToBeChanged.ManagerDeclined = true;
                booking.Pending = false;

                // Save JSON data
                for (int i = 0; i < customers.Count; i++)
                {
                    if (customers[i].Bookings == null)
                        continue;

                    for (int j = 0; j < customers[i].Bookings.Count; j++)
                    {
                        Booking currentBookingInLoop = customers[i].Bookings[j];

                        if (bookingToBeChanged.BookingID == currentBookingInLoop.BookingID)
                        {
                            customers[i].Bookings.Remove(currentBookingInLoop);
                            customers[i].Bookings.Add(bookingToBeChanged);
                            break;
                        }
                    }
                }

                this.UpdateJSON(customers);
            }
        }

        // Method to get customer data from a booking they have
        public Customer GetCustomerDataFromBookingID(int ID)
        {
            Customer cust = new Customer();

            List<Customer> customers = this.GetCustomerData();

            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].Bookings == null)
                    continue;

                for (int j = 0; j < customers[i].Bookings.Count; j++)
                {
                    if (ID == customers[i].Bookings[j].BookingID)
                    {
                        cust = customers[i];
                        break;
                    }
                }
            }

            return cust;
        }

        public Booking GetBookingFromWorkplan(Workplan workplan)
        {
            return this.GetCustomerBookingData().Find(bk => bk.BookingID == workplan.BookingID);             
        }

        // Method to validate date and time combo input when user requests a booking
        public bool DateAndTimeInputsAreValid(string combo)
        {
            string time = combo.Split(';')[0];
            string date = combo.Split(';')[1];

            // Validate time
            if (!(this.IsTime(time)))
            {
                return false;
            }

            // Validate date
            if (!(this.IsDate(date)))
            {
                return false;
            }

            // Validate that requested is not in the past
            if (DateTime.Now > Convert.ToDateTime(date))
            {
                return false;
            }

            return true;
        }

        // Method to detect if input time is actually a time
        private bool IsTime(string theTime)
        {
            return TimeSpan.TryParse(theTime, out var validateTime);
        }

        // Method to detect if input date is actually a date
        private bool IsDate(string TheDate)
        {
            return DateTime.TryParse(TheDate, out var validateDate);
        }

        public bool BookingHasEnoughNotice(string date)
        {
            DateTime today = DateTime.Now;
            DateTime bookingDay = Convert.ToDateTime(date);

            return (bookingDay - today).TotalDays > 2;
        }

        // Method to save all data in memory to .json files
        public void WriteJSON(Customer newCust, Staff newStaff)
        {
            if (newCust != null)
            {
                // Update customer data
                List<Customer> currentCustomers = this.GetCustomerData();

                if (currentCustomers != null)
                {
                    currentCustomers = this.GetCustomerData();
                }
                else
                {
                    currentCustomers = new List<Customer>();
                }

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

        // Method to update customer related json data
        private void UpdateJSON(List<Customer> customers)
        {
            string updatedCustomerData = JsonConvert.SerializeObject(customers, Formatting.Indented);
            File.WriteAllText(System.Web.Hosting.HostingEnvironment.MapPath(this.customerFile), updatedCustomerData);
        }

        // Method to update workplan related json data
        private void UpdateWorkplanJSON(List<Workplan> newWorkplans)
        {
            string updatedJSON = JsonConvert.SerializeObject(newWorkplans, Formatting.Indented);
            File.WriteAllText(System.Web.Hosting.HostingEnvironment.MapPath(this.workplan), updatedJSON);
        }
    }
}