using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class CargoTracking
    {
        [Key]
        public int CargoTrackingId { get; set; }
        [Column(TypeName = "Varchar(10)")]
        public string TrackingCode { get; set; }
        [Column(TypeName = "Varchar(300)")]
        public string Description { get; set; }

        public DateTime Date { get; set; }
    }
}
