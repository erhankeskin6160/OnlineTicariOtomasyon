using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTicariOtomasyon.Models.Classes
{
    public class Bill
    {
        [Key]
        public int BillId { get; set; }


        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string BillSeriNo { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string BillNo { get; set; }

        public string BillSequenceNo { get; set; }

        public DateTime Date { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string TaxAdministration{ get; set; }

        [Column(TypeName = "char")]
        [StringLength(5)]
        public string Hour {  get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DeliveryPerson {  get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Receiver { get; set; }


        public decimal Total { get; set; }
        public  virtual ICollection<Bill_Item> Bill_İtems { get; set; }    



    }
}
