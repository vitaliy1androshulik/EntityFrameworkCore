using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnitityFrameworkCore.Entities
{
    [Table("Passangers")]
    public class Client
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]//nvarchar(100)
        [Column("FirstName")]//set column name
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        public ICollection<Flight> Flights { get; set; }
    }
}
