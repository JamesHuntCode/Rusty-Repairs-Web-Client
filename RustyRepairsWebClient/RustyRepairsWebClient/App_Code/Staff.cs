using System;
using System.Collections.Generic;

namespace RustyRepairsWebClient
{
    public class Staff : User
    {
        public int ID { get; set; }
        public List<string> BusyDates { get; set; }

        public Staff()
        {
            
        }
    }
}