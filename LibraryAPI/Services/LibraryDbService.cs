using LibraryAPI.Interfaces;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Services
{
    public class LibraryDbService : ILibraryDbService
    {
        private LibraryDbContext _dbContext;
        public LibraryDbService(LibraryDbContext dbContext){
            this._dbContext = dbContext;
        }

        public List<BookDTO> GetAllBooks(string? order)
        {
            List<BookDTO> books = new List<BookDTO>();
            foreach(Book book in _dbContext.Books.Include(el => el.Rating).Include(el => el.Reviews))
            {
                books.Add(new BookDTO()
                {
                    Author = book.Author,
                    Id = book.Id,
                    Title = book.Title,
                    Rating = book.Rating.Score,
                    ReviewsNumber = book.Reviews.Count
                });
            }
            if (order != null && order.ToLower() == "title") books = books.OrderBy(el => el.Title).ToList();
            if (order != null && order.ToLower() == "authot") books = books.OrderBy(el => el.Author).ToList();
            return books;
        }

    }
}
