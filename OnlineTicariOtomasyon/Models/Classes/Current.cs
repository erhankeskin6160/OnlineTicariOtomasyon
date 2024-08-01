using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class Current
    {
        [Key]
        public int CurrentId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(29,ErrorMessage ="En Fazla 30 karakter yazabilirsiniz")]
        //[Required(ErrorMessage = "Bu Alanı Girmek Zorunludu !!")]
        public string CurrentName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En Fazla 30 Karakter Girilir")]
        //[Required(ErrorMessage = "Bu Alanı Girmek Zorunludur !!")]
        public string CurrentLastName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        [Required(ErrorMessage = "Bu Alanı Girmek Zorunludur !!")]
        public string CurrentCity{get;set;}

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CurrentMail { get; set; }

        public bool Durum {  get; set; }    

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string CurrentPassword { get; set; }
        [Column(TypeName = "Varchar"),StringLength(20)]
        public string Gender { get; set; }  
        public string? CurrentImage { get; set; }  
	 
       

        public virtual  ICollection<SalesActivity> SalesActivitys { get; set; }

    }
}
