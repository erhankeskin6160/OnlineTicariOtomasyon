using OnlineTicariOtomasyon.Models.Classes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string ProductName {  get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string  Brand { get; set; }   
        
        public short Stock { get; set; } 
        
        public decimal PurchasePrice { get; set; } 
        public decimal SalePrice { get; set; }

        public bool Status { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string Product_Img {  get; set; }

       
        
     public int CategoryId { get; set; }    
        public virtual Category Category { get;set; }  
    public virtual ICollection<SalesActivity> SalesActivitys { get; set; }


    }
}
