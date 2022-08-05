using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.RequestModels
{
    public class ScoreRequestModel
    {
        [Required]
        [Range(0, 5.01, ErrorMessage = "Score must be btw 0 and 5")]
        public string Score { get; set; }
    }
}
