using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBooking.ViewModels
{
    public class ConcertDescriptionViewModel
    {
        public int ID { get; set; }

        public string NameOfConcert { get; set; }

        public string TypeOfThisConcert { get; set; }

        public string TypeOfVoice { get; set; }

        public string Healiner { get; set; }

        public string Way { get; set; }

        public string Composer { get; set; }

        public string AgeLimit { get; set; }
    }
}
