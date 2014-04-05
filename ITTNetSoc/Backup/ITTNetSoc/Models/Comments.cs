using System.ComponentModel.DataAnnotations;

namespace ITTNetSoc.Models
{
    public class Comments
    {
        [Key]
        [Required]
        public int commentID { get; set; }

        [Required]
        public int itemID { get; set; }

        [Required]
        public string commentType { get; set; }

        [Required]
        public string author { get; set; }

        [Required]
        [Display(Name = "AuthorID")]
        public int AuthorID { get; set; } //For when going to authors user profile

        [Display(Name = "Comment Title")]
        public string title { get; set; }

        [Required]
        [Display(Name = "Comment Text")]
        public string body { get; set; }

        [Required]
        public string date { get; set; }

        [Required]
        public string time { get; set; }
    }
}