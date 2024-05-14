using OnlineTicariOtomasyon.Models.Classes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]

        
        public string Name { get; set; }
        
        public virtual   ICollection<Product>Products { get; set; }   

    }
}
