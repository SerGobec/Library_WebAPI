using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.RequestModels
{
    public class ScoreRequestModel
    {
        [Required]
        public string Score { get; set; }
    }
}
