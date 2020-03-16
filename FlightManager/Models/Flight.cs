using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Models
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }
        public string LocationFrom { get; set; }
        public string Destination { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfDeparture { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan DepartureHour { get; set; }
        [DataType(DataType.Date)]
        public DateTime ArrivalDate { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan ArrivalHour { get; set; }
        public TimeSpan FlightDuration { get; set; }
        public string Plane { get; set; }
        public string PlaneNumber { get; set; }
        public string PilotName { get; set; }
        public int TotalPassengersSeats { get; set; }
        public int TotalBusinessClassSeats { get; set; }
        public int FreeSeats { get; set; }
        public int FreeBusinessClass { get; set; }
        [NotMapped]
        public List<int> TicketNumber { get; set; } = new List<int>() { 1, 2, 3 };
    }
}
