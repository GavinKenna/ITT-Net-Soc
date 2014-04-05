using System.ComponentModel.DataAnnotations;

namespace ITTNetSoc.Models
{
    public partial class Album
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Album Name")]
        public string AlbumName { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public string date { get; set; }

        public string time { get; set; }

        //   public List<int> pictureID {get; set;}
        //Picture class must hold the album id, not the other way around. Yaay, a whole shift in direction...
    }

    public partial class CreateAlbumModel
    {
        [Required]
        [Display(Name = "Album Name")]
        public string AlbumName { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        // public List<int> pictureID { get; set; }
    }
}