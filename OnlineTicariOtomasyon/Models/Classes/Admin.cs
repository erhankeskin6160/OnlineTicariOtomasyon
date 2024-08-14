using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string Username { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string Password {  get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Authority { get; set; }



    }
}
