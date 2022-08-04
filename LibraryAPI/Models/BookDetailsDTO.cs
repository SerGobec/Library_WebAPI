namespace LibraryAPI.Models
{
    public class BookDetailsDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Cover { get; set; }
        public string Content { get; set; }
        public decimal Rating { get; set; }
        public List<ReviewDto> Reviews { get; set; }

        public BookDetailsDTO() => Reviews = new List<ReviewDto>();
    }
}
