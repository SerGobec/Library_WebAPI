using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
    public class Review
    {
        [Key]
        public long Id { get; set; }
        public long BookId { get; set; }
        public string? Message { get; set; }
        public string? Reviewer { get; set; }

        [ForeignKey("BookId")]
        public Book Book {get;set;}
    }
}
