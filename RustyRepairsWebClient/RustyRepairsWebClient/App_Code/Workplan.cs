namespace RustyRepairsWebClient
{
    public class Workplan
    {
        public int BookingID { get; set; }
        public int WorkPlanID { get; set; }

        public string DateStarted { get; set; }
        public string EstimatedCompletionDate { get; set; }
        public string ActualCompletionDate { get; set; }

        public int AssignedStaffMemberID { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
       

        public Workplan()
        {
            
        }
    }
}