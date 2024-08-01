using System.ComponentModel.DataAnnotations;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class SalesActivity
    {
        [Key]
        public int SalesId { get; set; }

         public string   Date{ get; set; }= DateTime.Now.ToShortDateString() ;
        public int Quantity { get; set; }  
        public decimal Price { get; set; }
        public decimal TotalAmount{ get; set; }
        public int Currentid { get; set; }
        public int Personelid { get; set; }
        public int Productid { get; set; }
        
       
        public virtual Product Product { get; set; }  
        public virtual Current Current { get; set; }  

        public virtual Personel Personel { get; set; }    
    } 

    
}
