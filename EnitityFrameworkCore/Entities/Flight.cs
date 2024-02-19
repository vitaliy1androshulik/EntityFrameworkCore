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
        [Key]//Primary Key
        public int Id { get; set; }
        public string DepartureSity { get; set; }
        [Required, MaxLength(100)]
        public string ArrivalSity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        //Relational type : One to many (1.....*)
        public int AirplaneId { get; set; }
        public Airplane Airplane { get; set; }//null
                                              //Relational type : Many to many (*.....*)
        public ICollection<Client> Clients { get; set; }
    }
}
