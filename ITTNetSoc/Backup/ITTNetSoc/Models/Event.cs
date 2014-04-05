using System.ComponentModel.DataAnnotations;

namespace ITTNetSoc.Models
{
    public partial class Event
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Event Name")]
        public string EventName { get; set; }

        [Required]
        [Display(Name = "Author")]
        public string Author { get; set; }

        [Required]
        [Display(Name = "AuthorID")]
        public int AuthorID { get; set; } //For when going to authors user profile

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Event Description")]
        public string Body { get; set; }

        [Required]
        [Display(Name = "Event Date")]
        public string date { get; set; }

        [Required]
        [Display(Name = "Event Time")]
        public string time { get; set; }

        [Required]
        [Display(Name = "Event Location")]
        public string mapLocation { get; set; }
    }
}