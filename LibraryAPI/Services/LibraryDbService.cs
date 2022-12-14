using LibraryAPI.Interfaces;
using LibraryAPI.Models;
using LibraryAPI.RequestModels;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Services
{
    public class LibraryDbService : ILibraryDbService
    {
        private LibraryDbContext _dbContext;
        private string _password;
        public LibraryDbService(LibraryDbContext dbContext, IConfiguration configuration){
            this._dbContext = dbContext;
            this._password = configuration.GetSection("PasswordSection").GetSection("Password").Value;
        }

        

        public List<BookDTO> GetAllBooks(string? order)
        {
            List<BookDTO> books = new List<BookDTO>();
            foreach(Book book in _dbContext.Books.Include(el => el.Rating).Include(el => el.Reviews))
            {
                BookDTO dto = new BookDTO();
                dto.Author = book.Author;
                dto.Id = book.Id;
                dto.Title = book.Title;
                if (book.Rating != null) dto.Rating = book.Rating.Score;
                if(book.Reviews.Count != 0) dto.ReviewsNumber = book.Reviews.Count;
                books.Add(dto);
            }
            if (order != null && order.ToLower() == "title") books = books.OrderBy(el => el.Title).ToList();
            if (order != null && order.ToLower() == "author") books = books.OrderBy(el => el.Author).ToList();
            return books;
        }

        public BookDetailsDTO GetBookDetails(long? id)
        {
            Book? book = _dbContext.Books.Where(el => el.Id == id).Include(el => el.Rating).Include(el => el.Reviews).FirstOrDefault();
            if (book == null) return null;
            BookDetailsDTO details = new BookDetailsDTO();
            details.Id = book.Id;
            details.Author = book.Author;
            details.Cover = book.Cover;
            details.Content = book.Content;
            details.Title = book.Title;
            if(book.Rating != null) details.Rating = book.Rating.Score;
            foreach (Review review in book.Reviews)
            {
                details.Reviews.Add(new ReviewDto()
                {
                    Id = review.Id,
                    Message = review.Message,
                    Reviewer = review.Reviewer
                });
            }
            return details;
        }

        public List<BookDTO> GetRecomended(string? genre)
        {
            List<BookDTO> resultArr = new List<BookDTO>();
            List<Book> books = _dbContext.Books.Include(el => el.Rating).Include(el => el.Reviews).ToList();
            if (genre != null) books = books.Where(el => el.Genre.ToLower().Contains(genre.ToLower())).ToList();
            foreach (Book book in books)
            {
                BookDTO bookDTO = new BookDTO();
                bookDTO.Author = book.Author;
                bookDTO.Id = book.Id;
                bookDTO.Title = book.Title;
                if (book.Rating != null) bookDTO.Rating = book.Rating.Score;
                if (book.Reviews != null) bookDTO.ReviewsNumber = book.Reviews.Count;
                resultArr.Add(bookDTO);
            }
            resultArr = resultArr.OrderByDescending(el => el.Rating).ToList();
            if (resultArr.Count > 10) resultArr = resultArr.Take(10).ToList();
            return resultArr;
        }

        public bool CheckPassword(string? password)
        {
            if (password != null && password == this._password) return true;
            return false;
        }

        public async Task<bool> DeleteBookAsync(long id, string password)
        {
            if (password != this._password) return false;
            Book book = _dbContext.Books.Where(el => el.Id == id).FirstOrDefault();
            if (book == null) return false;
            _dbContext.Remove(book);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CreateBook(BookRequestModel model)
        {
            try
            {
                Book book = _dbContext.Books.Where(el => el.Id == model.Id).FirstOrDefault();
                if (book != null)
                {
                    book.Author = model.Author;
                    book.Content = model.Content;
                    book.Cover = model.Cover;
                    book.Title = model.Title;
                    book.Genre = model.Genre;
                    _dbContext.Update(book);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    book = new Book();
                    book.Author = model.Author;
                    book.Content = model.Content;
                    book.Cover = model.Cover;
                    book.Title = model.Title;
                    book.Genre = model.Genre;
                    _dbContext.Add(book);
                    await _dbContext.SaveChangesAsync();
                }
                return true;
            } catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> CreateReview(long id, ReviewRequestModel model)
        {
            try
            {
                Book book = _dbContext.Books.Where(el => el.Id == id).FirstOrDefault();
                if (book == null) return false;
                Review review = new Review()
                {
                    BookId = id,
                    Message = model.Message,
                    Reviewer = model.Reviewer
                };
                _dbContext.Add(review);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> CreateScore(long id, decimal score)
        {
            try
            {
                Rating rating = _dbContext.Ratings.Where(el => el.BookId == id).FirstOrDefault();
                if (rating == null)
                {
                    rating = new Rating();
                    rating.Score = score;
                    rating.BookId = id;
                    _dbContext.Add(rating);
                }
                else
                {
                    rating.Score = score;
                    _dbContext.Update(rating);
                }
                await _dbContext.SaveChangesAsync();
                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }

        public bool ContainBookById(long id)
        {
            return _dbContext.Books.Where(el => el.Id == id).Count() > 0;
        }
    }
}
