using System.ComponentModel.DataAnnotations;

namespace ITTNetSoc.Models
{
    public partial class NewsItem
    {
        [Required]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Headline")]
        public string Headline { get; set; }

        [Required]
        [Display(Name = "Author")]
        public string Author { get; set; }

        [Required]
        [Display(Name = "AuthorID")]
        public int AuthorID { get; set; } //For when going to authors user profile

        [Required]
        [Display(Name = "Summary")]
        public string Summary { get; set; }

        [Required]
        [Display(Name = "Body")]
        public string Body { get; set; }

        [Display(Name = "News Art Url...")]
        public string NewsArtUrl { get; set; }
    }
}