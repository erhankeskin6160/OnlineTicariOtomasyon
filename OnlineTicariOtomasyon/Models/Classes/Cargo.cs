using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class Cargo
    {
        
        public int CargoId { get; set; }
        [Column(TypeName = "Varchar(310)")]
        public string Description { get; set; }
        [Column(TypeName = "Varchar(10)")]
        public string TrackingCode { get; set; }
        [Column(TypeName = "Varchar(30)")]
        public string Personel { get; set; }
        [Column(TypeName = "Varchar(20)")]
        public string Receiver { get; set; }
         
        public string? Date { get; set; } 

    }
}
