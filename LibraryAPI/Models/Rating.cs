using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
    public class Rating
    {
        [Key]
        public long Id { get; set; }
        public long BookId { get; set; }
        public decimal Score { get; set; }
        
        [ForeignKey("BookId")]
        Book Book { get; set; }
    }
}
