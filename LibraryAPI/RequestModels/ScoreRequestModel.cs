using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.RequestModels
{
    public class ScoreRequestModel
    {
        [Required]
        [Range(1, 5.01, ErrorMessage = "Score must be btw 1 and 5")]
        public string Score { get; set; }
    }
}
