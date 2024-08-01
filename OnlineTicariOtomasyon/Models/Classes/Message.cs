using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Sender { get; set; }
        
        [StringLength(50)]
        [Column(Order =2,TypeName ="Varchar")]
       public string Receiver { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Subject { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string Content { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
    }
}
