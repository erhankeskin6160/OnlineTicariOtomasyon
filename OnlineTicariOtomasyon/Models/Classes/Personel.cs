using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Personel_Last_Name {  get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string PersoneImage { get; set; }

        public virtual   ICollection<SalesActivity> SalesActivitys { get; set; }
        public int Departmentid { get; set; }
        public virtual Department Department{get; set; }
    }
}
