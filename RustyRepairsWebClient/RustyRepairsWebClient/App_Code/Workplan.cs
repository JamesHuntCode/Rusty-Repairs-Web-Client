﻿namespace RustyRepairsWebClient
{
    public class Workplan
    {
        public int WorkPlanID { get; set; }

        public string DateStarted { get; set; }
        public string EstimatedCompletionDate { get; set; }
        public string ActualCompletionDate { get; set; }

        public Staff AssignedStaffMember { get; set; }

        public Workplan()
        {
            
        }
    }
}