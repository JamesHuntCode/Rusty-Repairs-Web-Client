namespace RustyRepairsWebClient
{
    public class Booking
    {
        public int CustomerID { get; set; }
        public int BookingID { get; set; }

        public bool Pending { get; set; } = true;
        public bool ManagerApproved { get; set; } = false;
        public bool ManagerDeclined { get; set; } = false;
        public bool Completed { get; set; } = false;
        public bool Canceled { get; set; } = false;

        public string Date { get; set; }
        public string Time { get; set; }

        public string ProblemSummary { get; set; }

        public Booking()
        {
            
        }
    }
}