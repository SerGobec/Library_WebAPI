using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.RequestModels
{
    public class ReviewRequestModel
    {
        [Required]
        public string Message { get; set; }
        [Required]
        public string Reviewer { get; set; }
    }
}
