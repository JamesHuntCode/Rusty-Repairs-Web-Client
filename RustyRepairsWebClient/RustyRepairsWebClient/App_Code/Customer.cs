﻿using System;
using System.Collections.Generic;

namespace RustyRepairsWebClient
{
    public class Customer : User
    {
        public int CustomerID { get; set; }

        public string JoinDate { get; set; }

        public List<Booking> Bookings = new List<Booking>();

        public bool HasMissedBooking { get; set; }
        public bool HasActiveAccount { get; set; }

        public List<Vehicle> Vehicles = new List<Vehicle>();

        public Customer()
        {

        }

        // Method to get summary of customer data
        public string GetCustomerSummary()
        {
            string ID = this.CustomerID.ToString();
            string firstName = this.FirstName;
            string lastName = this.LastName;
            string email = this.EmailAddress;
            string dateJoined = this.JoinDate;

            string formattedOutput = ID + ";" + firstName + ";" + lastName + ";" + email + ";" + dateJoined;

            return formattedOutput;
        }

        // Method to find out if a customer has any upcoming bookings (will determine if they can delete their account)
        public bool HasUpcomingBooking()
        {
            List<Booking> upcomingBookings = this.GetAllCustomerBookings("upcoming");
            for (int i = 0; i < upcomingBookings.Count; i++)
            {
                if ((Convert.ToDateTime(upcomingBookings[i].Date) - DateTime.Now).Days > 7)
                {
                    return true;
                }
            }

            return false;
        }

        // Method to get all customer bookings 
        public List<Booking> GetAllCustomerBookings(string preference)
        {
            List<Booking> fetchedBookings = new List<Booking>();

            switch (preference)
            {
                case "upcoming":

                    for (int i = 0; i < this.Bookings.Count; i++)
                    {
                        DateTime now = DateTime.Now;
                        DateTime bookingDate = Convert.ToDateTime(this.Bookings[i].Date);

                        if (bookingDate > now)
                        {
                            fetchedBookings.Add(this.Bookings[i]);
                        }
                    }

                    break;
                case "past":

                    for (int i = 0; i < this.Bookings.Count; i++)
                    {
                        DateTime now = DateTime.Now;
                        DateTime bookingDate = Convert.ToDateTime(this.Bookings[i].Date);

                        if (bookingDate < now)
                        {
                            fetchedBookings.Add(this.Bookings[i]);
                        }
                    }

                    break;
                case "requested":

                    for (int i = 0; i < this.Bookings.Count; i++)
                    {
                        if (this.Bookings[i].Pending)
                        {
                            fetchedBookings.Add(this.Bookings[i]);
                        }
                    }

                    break;
                case "declined":

                    for (int i = 0; i < this.Bookings.Count; i++)
                    {
                        if (!(this.Bookings[i].Pending)  && !(this.Bookings[i].ManagerApproved))
                        {
                            fetchedBookings.Add(this.Bookings[i]);
                        }
                    }

                    break;

                case "all":

                    for(int i = 0; i < this.Bookings.Count; i++)
                    {
                        fetchedBookings.Add(this.Bookings[i]);
                    }

                    break;
            }

            return fetchedBookings;
        }
    }
}