using System;
using System.Collections.Generic;
using Ticketing.Enums;

namespace Ticketing.Models
{
    [Serializable]
    public class Event
    {
        public string Name { get; set; }
        public int SittingStage { get; set; }
        public int StandingStage { get; set; }
        public int StandingOpen { get; set; }

        //public Dictionary<TicketCategory, int> TicketCategories { get; set; }
    }
}
