using System;

namespace RustyRepairsWebClient
{
    public class Booking
    {
        public bool Pending { get; set; } = true;
        public bool ManagerApproved { get; set; } = false;
        public bool Completed { get; set; } = false;

        public string Date { get; set; }
        public string ProblemSummary { get; set; }

        public Booking()
        {
            
        }
    }
}