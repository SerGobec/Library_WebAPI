using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.RequestModels
{
    public class BookRequestModel
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Cover { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Author { get; set; }
    }
}
