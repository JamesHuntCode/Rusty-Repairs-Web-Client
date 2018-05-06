using System;
using System.Collections.Generic;

namespace RustyRepairsWebClient
{
    public class Staff : User
    {
        public List<string> BusyDates { get; set; }

        public Staff()
        {
            
        }
    }
}