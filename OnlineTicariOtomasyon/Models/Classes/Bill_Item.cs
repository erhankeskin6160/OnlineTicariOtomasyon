using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class Bill_Item
    {
        [Key]
        public int BillItemId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Description { get; set; } 

        public int Quantity { get; set; }   

        public decimal UnitPrice {  get; set; }  

        public decimal TotalAmount {  get; set; }   
       public  int BillId { get; set; }    
       
        public virtual Bill  Bills { get; set; } 


    }
}
