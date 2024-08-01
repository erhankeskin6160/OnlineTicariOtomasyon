using Microsoft.AspNetCore.Razor.TagHelpers;

namespace OnlineTicariOtomasyon.Models.Classes
{
    [HtmlTargetElement("mytag")]
    public class ClassGroup:TagHelper
    {
        public string Sehir { get; set; }
        public int Sayı { get; set;}
    }
}
