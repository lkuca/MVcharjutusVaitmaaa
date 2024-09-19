using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Dexter
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }
        [Display(Name ="Dexter ID")]

        public int EntryID { get; set; }
        [Display(Name = "region of discovery ID")]
        public string ElementType { get; set; }

        public string ImageUrl { get; set; }
    }
}
