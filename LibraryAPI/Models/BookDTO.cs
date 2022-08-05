﻿namespace LibraryAPI.Models
{
    public class BookDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Rating { get; set; }
        public decimal ReviewsNumber { get; set; }

    }
}
