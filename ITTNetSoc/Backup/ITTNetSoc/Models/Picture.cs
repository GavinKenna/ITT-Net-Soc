using System.ComponentModel.DataAnnotations;

namespace ITTNetSoc.Models
{
    public partial class Picture
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Source")]
        public string Source { get; set; }

        [Required]
        [Display(Name = "AlbumId")]
        public int AlbumId { get; set; }
    }

    public partial class CreatePictureModel
    {
        [Required]
        [Display(Name = "Source")]
        public string Source { get; set; }

        [Required]
        [Display(Name = "AlbumId")]
        public int AlbumId { get; set; }
    }
}