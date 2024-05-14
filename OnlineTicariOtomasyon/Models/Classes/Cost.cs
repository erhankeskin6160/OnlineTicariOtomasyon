using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class Cost
    {
        [Key]
        public int CostId { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string CostDescription {  get; set; }    

        public DateTime DateTime { get; set; }

        public decimal Amount { get; set; } 


    }
}
