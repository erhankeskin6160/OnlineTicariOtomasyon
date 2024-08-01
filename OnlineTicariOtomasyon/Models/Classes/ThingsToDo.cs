using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class ThingsToDo
    {
        [Key]
        public int ThingsToDoId { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(100)]
        public string ThingsToDoName { get; set; }
       

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Remainingtime { get; set; }
        [Column(TypeName = "bit")]
        public bool ThingsToDoStatus { get; set; }
    }
}
