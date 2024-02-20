using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnitityFrameworkCore.Entities
{
    public class Flight
    {
        public int Id { get; set; }
        public string DepartureSity { get; set; }
        public string ArrivalSity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int? Rating { get; set; }
        public int AirplaneId { get; set; }
        public Airplane Airplane { get; set; }                                     
        public ICollection<Client> Clients { get; set; }
    }
}
