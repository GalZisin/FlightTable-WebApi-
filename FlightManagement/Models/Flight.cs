using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagement.Models
{
    public class Flight
    {
        public long FlightNO { get; set; }
        public string OriginCountry { get; set; }
        public string DestinationCountry { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int Price { get; set; }
        public int SeatAmount { get; set; }
        public long CompanyID { get; set; }
    }
    
}