using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class ProductDetail
    {
        [Key]
        public int  DetailId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)] 
        public string ProductName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(1000)]
        public string ProductInfo { get; set; } 


    }
}
