﻿namespace RustyRepairsWebClient
{
    public class Vehicle
    {
        public int CustomerID { get; set; }

        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string CarRegistration { get; set; }
        public string OwnerName { get; set; }

        public Vehicle()
        {
            
        }
    }
}